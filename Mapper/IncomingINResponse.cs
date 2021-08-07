using Newtonsoft.Json;

namespace NewsGraph.Mapper
{
    public class IncomingINResponse
    {
        //
        //[JsonProperty("#cdata-section")]
        public string title { get; set; }
        public string link { get; set; }
        //public string description { get; set; }
        //public string category { get; set; }

        //[JsonProperty("guid")]
        //public Urlhash UrlGuid { get; set; }
        //public string PubDate { get; set; }
        //public PubSource Source { get; set; }
    }
    //public class Urlhash
    //{
    //    [JsonProperty("#cdata-section")]
    //    public string UrlGuid { get; set; }
    //}
    //public class PubSource
    //{
    //    [JsonProperty("@url")]
    //    public string Url { get; set; }
    //    [JsonProperty("#text")]
    //    public string Publisher { get; set; }
    //}
}



//{
//    "title": {
//        "#cdata-section": "Once largely Covid free, Asian economies are now upended by delta"
//    },
//    "author": {
//        "#cdata-section": "Bloomberg"
//    },
//    "category": {
//        "#cdata-section": "Economy"
//    },
//    "link": "https://www.thehindubusinessline.com/economy/once-largely-covid-free-asian-economies-are-now-upended-by-delta/article35780777.ece",
//    "description": {
//        "#cdata-section": "\r\n                The countries that were successful in containing the virus a year back, are have imposed strict restrictions with infections returning\r\n            "
//    },
//    "pubDate": {
//        "#cdata-section": "Sat, 07 Aug 2021 10:57:45 +0530"
//    }
//},