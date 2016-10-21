using Newtonsoft.Json;

namespace Shariff.Backend.ShareCounts
{
    public class GooglePlusResponse
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("result")]
        public dynamic Result { get; set; }

    }
}
