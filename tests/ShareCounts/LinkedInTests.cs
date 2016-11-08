using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using Shariff.Backend.ShareCounts;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;


namespace Shariff.Backend.Tests.ShareCounts
{
    public class LinkedInTests
    {
        [Fact]
        public async Task ShouldReturnTheExpectedCount()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{ \"count\": 459, \"fCnt\": \"0\", \"fCntPlusOne\": \"1\", \"url\": \"http://www.dotnetgeek.de/test-url\" }");

                var logger = new Mock<ILogger>().Object;
                var count = await new LinkedIn(logger).Get("http://www.dotnetgeek.de/test-url");

                httpTest.ShouldHaveCalled("https://www.linkedin.com/countserv/count/share*")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                Assert.Equal(459, Convert.ToInt32(count));
            }
        }
    }
}
