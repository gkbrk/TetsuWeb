using System.Collections.Generic;
using Tetsu.Web.Http;
using Tetsu.Web.Middleware;

namespace Tetsu.Web.Router {
    public class OrderedRouter : IRouter {
        private readonly IList<(IRouteMatcher, IMiddleware)> routes;

        public OrderedRouter() {
            routes = new List<(IRouteMatcher, IMiddleware)>();
        }

        public override void AddRoute(IRouteMatcher route, IMiddleware middleware) {
            routes.Add((route, middleware));
        }

        public override IMiddleware GetMatchingRoute(Request request) {
            foreach (var (route, action) in routes) {
                if (route.IsMatch(request)) {
                    return action;
                }
            }

            return null;
        }
    }
}
