using Newtonsoft.Json;

namespace Shariff.Backend.ShareCounts
{
    public class XingResponse
    {
        [JsonProperty("share_counter")]
        internal string ShareCounter { get; set; }
    }
}
