using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;

namespace Shariff.Backend.ShareCounts
{
    public class Facebook : ShareCountServiceBase
    {
        public Facebook(
            ILogger logger)
            :base("facebook", logger)
        {
        }

        protected override async Task<string> CallService(
            string url)
        {
            var result = await "https://graph.facebook.com/"
                .SetQueryParams(new
                {
                    id = url
                })
                .GetJsonAsync<FacebookResponse>();

            return result.Share.Count;
        }
    }
}
