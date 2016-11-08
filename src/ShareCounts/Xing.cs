using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;

namespace Shariff.Backend.ShareCounts
{
    public class Xing : ShareCountServiceBase
    {
        public Xing(
            ILogger logger) : 
            base("xing", logger)
        {
        }

        protected override async Task<string> CallService(string url)
        {
            var result = await "https://www.xing-share.com/spi/shares/statistics"
                .PostUrlEncodedAsync(new { url = url })
                .ReceiveJson<XingResponse>();

            return result.ShareCounter;
        }
    }
}
