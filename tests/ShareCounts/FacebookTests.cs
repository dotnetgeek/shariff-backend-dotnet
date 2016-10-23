using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using Shariff.Backend.ShareCounts;
using Xunit;


namespace Shariff.Backend.Tests.ShareCounts
{
    public class FacebookTests
    {

        [Fact]
        public async void ShouldReturnTheCount()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{ \"og_object\": { "+
                    "\"id\": \"3333333\", \"description\": \"dotnet.\", " +
                    "\"title\": \"dotnet.\", \"type\": \"website\", " +
                    "\"updated_time\": \"2016-10-09T22:43:47+0000\" }, \"share\": { \"comment_count\": 0, \"share_count\": 67284 }," +
                    "\"id\": \"http://www.dotnetgeek.de/test-url\"}");

                var count = await new Facebook().Get("http://www.dotnetgeek.de/test-url");

                httpTest.ShouldHaveCalled("https://graph.facebook.com/?id=*")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                Assert.Equal(67284, Convert.ToInt32(count));
            }
        }

    }
}
