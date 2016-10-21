using System.Threading.Tasks;
using Flurl.Http;

namespace Shariff.Backend.ShareCounts
{
    public class GooglePlus : ShareCountServiceBase
    {
        public GooglePlus() : 
            base("googleplus")
        {
        }

        protected override async Task<string> CallService(string url)
        {
            var result = await "https://clients6.google.com/rpc?key=AIzaSyCKSbrvQasunBoV16zDH9R33D88CeLr9gQ"
                   .PostJsonAsync(new
                   {
                       method = "pos.plusones.get",
                       id = "p",
                       @params = new
                       {
                           nolog = true,
                           id = url,
                           source = "widget",
                           userId = "@viewer",
                           groupId = "@self"
                       },
                       jsonrpc = "2.0",
                       key = "p",
                       apiVersion = "v1"
                   })
                   .ReceiveJson<GooglePlusResponse>();

            return result.Result.metadata.globalCounts.count;
        }
    }
}
