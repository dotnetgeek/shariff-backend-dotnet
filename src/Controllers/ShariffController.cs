using Microsoft.AspNetCore.Mvc;

namespace Shariff.Backend.Controllers
{
    [Route("shares")]
    public class ShariffController : Controller
    {
        [HttpGet("counts")]
        public IActionResult GetCounts(
            string url)
        {
            return Json(new { });
        }
    }
}