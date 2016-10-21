using System;
using System.Net.Http;
using Flurl.Http.Testing;
using Shariff.Backend.ShareCounts;
using Xunit;

namespace Shariff.Backend.Tests.SocialMediaServices
{
    public class GooglePlusTests
    {

        [Fact]
        public async void ShouldReturnTheExpectedCount()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{\"id\": \"p\", " +
                              "\"result\": { " +
                                 "\"kind\": \"pos#plusones\", " +
                                 "\"id\": \"http://www.dotnetgeek.de/\", " +
                                 "\"isSetByViewer\": false, " +
                                 "\"metadata\": { " +
                                     "\"type\": \"URL\", " +
                                     "\"globalCounts\": { " +
                                         "\"count\": 5 " +
                                     "} " +
                                 "}, " +
                             "\"abtk\": \"AEIZW7RCLlF9ulguYp8iJbril2j7SiWeBqorYwHNdpN8uxrf1lJRthyvYT4qhzbsBq5S+lwiewI/\"}}");

                var count = await new GooglePlus().Get("http://www.dotnetgeek.de/test-url");

                httpTest.ShouldHaveCalled("https://clients6.google.com/rpc?key=*")
                    .WithVerb(HttpMethod.Post)
                    .Times(1);

                Assert.Equal(5, Convert.ToInt32(count));
            }
        }

    }
}
