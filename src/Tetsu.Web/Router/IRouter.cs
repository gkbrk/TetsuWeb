using Tetsu.Web.Http;
using System;
using Tetsu.Web.Middleware;

namespace Tetsu.Web.Router {
    public abstract class IRouter : IMiddleware {
        public void Process(HttpContext context) {
            var route = GetMatchingRoute(context.Request);

            if (route != null) {
                context.Response.StatusCode = 200;
                route.Process(context);
            } else {
                context.Response.StatusCode = 404;
                context.Response.TextContent = "404 Not Found\n";
            }
        }

        public abstract void AddRoute(IRouteMatcher route, IMiddleware middleware);
        public abstract IMiddleware GetMatchingRoute(Request request);


    }
}
