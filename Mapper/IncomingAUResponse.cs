using Newtonsoft.Json;

namespace NewsGraph.Mapper
{
    public class IncomingAUResponse
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string category { get; set; }

        [JsonProperty("guid")]
        public Urlhash UrlGuid { get; set; }
        public string PubDate { get; set; }
        public PubSource Source { get; set; }
    }
    public class Urlhash
    {
        [JsonProperty("#text")]
        public string UrlGuid { get; set; }
    }
    public class PubSource
    {
        [JsonProperty("@url")]
        public string Url { get; set; }
        [JsonProperty("#text")]
        public string Publisher { get; set; }
    }
}
