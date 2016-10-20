using System.Collections.Generic;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shariff.Backend.ShareCounts;

namespace Shariff.Backend.Controllers
{
    [Route("shares")]
    public class ShariffController : Controller
    {
        [HttpGet("counts")]
        public async Task<IActionResult> GetCounts(
            string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            if (!url.StartsWith("http", System.StringComparison.Ordinal) && !url.Contains("://"))
                url = "http://" + url;

            var encodeUrl = HtmlEncoder.Default.Encode(url);

            var result = new Dictionary<string, string>();

            var xingCounter = await new Xing().Get(encodeUrl);
            if (!string.IsNullOrWhiteSpace(xingCounter))
                result.Add("xing", xingCounter);

            return Json(result);
        }
    }
}