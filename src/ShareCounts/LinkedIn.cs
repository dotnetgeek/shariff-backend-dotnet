using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace Shariff.Backend.ShareCounts
{
    public class LinkedIn : ShareCountServiceBase
    {
        public LinkedIn() :
            base("linkedin")
        {
        }

        protected override async Task<string> CallService(
            string url)
        {
            var result = await "https://www.linkedin.com/countserv/count/share"
                .SetQueryParams(new
                {
                    url = url,
                    lang = "de_DE",
                    format = "json"
                })
                .GetJsonAsync<LinkedInResponse>();

            return result.Count;
        }
    }
}
