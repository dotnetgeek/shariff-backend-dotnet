using Newtonsoft.Json;

namespace Shariff.Backend.ShareCounts
{
    /*

        {
    "count": 0,
    "fCnt": "0",
    "fCntPlusOne": "1",
    "url": "http://www.dotnetgeek.de/test"
}

    */

    public class LinkedInResponse
    {
        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
