using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shariff.Backend.Controllers;
using Xunit;

namespace Shariff.Backend.Tests
{
    public class ShariffControllerTests
    {
        private readonly IActionResult _actionResult;

        public ShariffControllerTests()
        {
            var controller = new ShariffController();
            _actionResult = controller.GetCounts(
                "http://www.dotnetgeek.de/about-me");
        }

        [Fact]
        public void ShouldMatchTheExpectedControllerResult()
        {
            var jsonResult = _actionResult as JsonResult;

            var expectedContent = new Dictionary<string, string>
            {
                ["facebook"] = "672",
                ["xing"] = "1",
                ["googleplus"] = "5"
            };

            Assert.NotNull(jsonResult);
            Assert.Equal(expectedContent, jsonResult.Value);
        }
    }
}