using Tetsu.Web.Http;
using Tetsu.Web.Middleware;
using Tetsu.Web.Router;
using Xunit;

namespace Tetsu.Web.Tests.Router {
    public class OrderedRouterTests {
        [Fact]
        public void MatchRoute_ShouldMatch() {
            var router = GetRouter();
            var req = Parser.ParseRequest("GET /test HTTP/1.1\r\n");

            Assert.NotNull(router.GetMatchingRoute(req));
        }

        [Fact]
        public void MatchRoute_ShouldNotMatch() {
            var router = GetRouter();
            var req = Parser.ParseRequest("GET /hmm HTTP/1.1\r\n");

            Assert.Null(router.GetMatchingRoute(req));
        }

        private IRouter GetRouter() {
            var router = new OrderedRouter();

            router.AddRoute(new ExactMatch("/test"), new FunctionMiddleware(x => {}));

            return router;
        }
    }
}