using Newtonsoft.Json;

namespace NewsGraph.Mapper
{
    public class IncomingINResponse
    {
        public TitleData title { get; set; }
        public string link { get; set; }
    }

    public class TitleData
    {
        [JsonProperty("#cdata-section")]
        public string Title { get; set; }
    }
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