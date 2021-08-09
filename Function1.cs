using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Xml;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using NewsGraph.Mapper;

namespace NewsGraph
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var url = await new StreamReader(req.Body).ReadToEndAsync();

            if (!string.IsNullOrWhiteSpace(url))
            {
                var httpClient = new HttpClient(); 
                var response = await httpClient.GetAsync(url); // above 2 lines are required to get data stream from server

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var xmlData = await response.Content.ReadAsStringAsync(); // this line will convert stream to xml string

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlData); // these 2 line will read xml data and load to doc

                    var jsonData = JsonConvert.SerializeXmlNode(doc); // this line will convert xml data in doc t0 json

                    var pruneData = PruneXml(jsonData); // this will remove unwanted json nodes.
                    try
                    {
                        var processedData = JsonConvert.DeserializeObject<IncomingINResponse[]>(pruneData); // this is to convert incoming foramt to outgoing format
                        return new OkObjectResult(processedData); // this is to finalize the out
                    }
                    catch (Exception ex)
                    {
                        return new OkObjectResult(ex.Message);
                    }
                }
                else {
                    return new OkObjectResult(response.ReasonPhrase);
                }
            }
            return new OkObjectResult("NOT OK");
        }

        public static string PruneXml(string jsonData)
        {
            return JObject.Parse(jsonData).SelectToken("rss").SelectToken("channel").SelectToken("item").ToString();
        }
    }
}
