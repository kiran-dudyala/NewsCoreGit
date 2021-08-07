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
                var httpClient = new HttpClient(); // init HttpClient Here
                var response = await httpClient.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var xmlData = await response.Content.ReadAsStringAsync();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlData);
                    var jsonData = JsonConvert.SerializeXmlNode(doc);
                    var pruneData = PruneXml(jsonData);
                    try
                    {
                        var processedData = JsonConvert.DeserializeObject<IncomingINResponse[]>(pruneData);
                        return new OkObjectResult(processedData);
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
