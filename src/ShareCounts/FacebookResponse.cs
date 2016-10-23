using Newtonsoft.Json;

namespace Shariff.Backend.ShareCounts
{
    internal struct FacebookResponse
    {
        [JsonProperty("id")]
        internal string Id { get; set; }

        [JsonProperty("share")]
        internal Share Share { get; set; }
    }

    internal struct Share
    {
        [JsonProperty("share_count")]
        internal string Count { get; set; }
    }
}
