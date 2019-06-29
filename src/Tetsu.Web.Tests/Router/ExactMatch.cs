using Tetsu.Web.Router;
using Tetsu.Web.Http;
using Xunit;

namespace Tetsu.Web.Tests.Router
{
    public class ExactMatchTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("/")]
        [InlineData("/test")]
        [InlineData("test")]
        public void ExactMatch_IsMatch(string route)
        {
            var router = new ExactMatch(route);
            var req = new Request
            {
                Uri = route
            };

            Assert.True(router.IsMatch(req));
        }
    }
}
