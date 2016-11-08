using Newtonsoft.Json;

namespace Shariff.Backend.ShareCounts
{
    public class LinkedInResponse
    {
        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
