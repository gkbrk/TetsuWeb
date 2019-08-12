#!t/cs-script

using Tetsu.Web.Router;
using Tetsu.Web.Http;
using Tetsu.Web.Middleware;

var router = new OrderedRouter();
router.AddRoute(new ExactMatch("/test"), new FunctionMiddleware(x => {}));

var req = Parser.ParseRequest("GET /test HTTP/1.1\r\n\r\n");
Ok(router.GetMatchingRoute(req) != null, "Route should match");

req = Parser.ParseRequest("GET /hmm HTTP/1.1\r\n\r\n");
Ok(router.GetMatchingRoute(req) == null, "Route should not match");

DoneTesting();
