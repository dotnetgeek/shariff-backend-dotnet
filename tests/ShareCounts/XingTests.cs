using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using Shariff.Backend.ShareCounts;
using Xunit;

namespace Shariff.Backend.Tests.ShareCounts
{
    public class XingTests
    {
        [Fact]
        public async Task ShouldReturnTheExpectedCount()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{ \"share_counter\": 209 }");

                var count = await new Xing().Get("http://www.dotnetgeek.de/test-url");


                httpTest.ShouldHaveCalled("https://www.xing-share.com/spi/shares/statistics")
                        .WithVerb(HttpMethod.Post)
                        .Times(1);

                Assert.Equal(209, Convert.ToInt32(count));
            }
        }
    }
}
