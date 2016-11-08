using System.Collections.Generic;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shariff.Backend.ShareCounts;

namespace Shariff.Backend.Controllers
{
    [Route("shares")]
    public class ShariffController : Controller
    {
        private readonly ILogger<ShariffController> _logger;

        public ShariffController(
          ILogger<ShariffController> logger)
        {
            _logger = logger;
        }

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

            var xingCount = await new Xing(_logger).Get(encodeUrl);
            if (!string.IsNullOrWhiteSpace(xingCount))
                result.Add("xing", xingCount);

            var linkedInCount = await new LinkedIn(_logger).Get(encodeUrl);
            if (!string.IsNullOrWhiteSpace(linkedInCount))
                result.Add("linkedin", linkedInCount);

            var googlePlusCount = await new GooglePlus(_logger).Get(encodeUrl);
            if (!string.IsNullOrWhiteSpace(googlePlusCount))
                result.Add("googleplus", googlePlusCount);

            var facebookCount = await new Facebook(_logger).Get(encodeUrl);
            if (!string.IsNullOrWhiteSpace(facebookCount))
                result.Add("facebook", facebookCount);


            return Json(result);
        }
    }
}