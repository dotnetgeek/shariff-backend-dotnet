using System.Threading.Tasks;
using Flurl.Http;

namespace Shariff.Backend.ShareCounts
{
    public class Xing : ShareCountServiceBase
    {
        public Xing() : 
            base("xing")
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
