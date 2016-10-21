using System;
using System.Collections.Generic;
using Flurl.Http.Testing;
using Microsoft.AspNetCore.Mvc;
using Shariff.Backend.Controllers;
using Xunit;

namespace Shariff.Backend.Tests
{
    public class ShariffControllerTests : IDisposable
    {
        private readonly HttpTest _httpTest;
        private readonly IActionResult _actionResult;

        public ShariffControllerTests()
        {
            _httpTest = new HttpTest();

            _httpTest
                //xing
                .RespondWith("{ \"share_counter\": 109 }")
                //googleplus
                .RespondWith("{\"id\": \"p\", " +
                              "\"result\": { " +
                                 "\"kind\": \"pos#plusones\", " +
                                 "\"id\": \"http://www.dotnetgeek.de/about-me\", " +
                                 "\"isSetByViewer\": false, " +
                                 "\"metadata\": { " +
                                     "\"type\": \"URL\", " +
                                     "\"globalCounts\": { " +
                                         "\"count\": 5 " +
                                     "} " +
                                 "}, " +
                             "\"abtk\": \"AEIZW7RCLlF9ulguYp8iJbril2j7SiWeBqorYwHNdpN8uxrf1lJRthyvYT4qhzbsBq5S+lwiewI/\"}}");


            var controller = new ShariffController();
            _actionResult = controller.GetCounts(
                "http://www.dotnetgeek.de/about-me").Result;
        }

        [Fact]
        public void ShouldMatchTheExpectedControllerResult()
        {
            var jsonResult = _actionResult as JsonResult;

            var expectedContent = new Dictionary<string, string>
            {
                ["xing"] = "109",
                ["googleplus"] = "5",
            };

            Assert.NotNull(jsonResult);
            Assert.Equal(expectedContent, jsonResult.Value);
        }

        public void Dispose()
        {
            _httpTest.Dispose();
        }
    }
}