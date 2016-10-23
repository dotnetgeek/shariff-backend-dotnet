using System;
using System.Net.Http;
using Flurl.Http.Testing;
using Shariff.Backend.ShareCounts;
using Xunit;

namespace Shariff.Backend.Tests.ShareCounts
{
    public class LinkedInTests
    {
        [Fact]
        public async void ShouldReturnTheCount()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{ \"count\": 459, \"fCnt\": \"0\", \"fCntPlusOne\": \"1\", \"url\": \"http://www.dotnetgeek.de/test-url\" }");

                var count = await new LinkedIn().Get("http://www.dotnetgeek.de/test-url");

                httpTest.ShouldHaveCalled("https://www.linkedin.com/countserv/count/share*")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                Assert.Equal(459, Convert.ToInt32(count));
            }
        }
    }
}
