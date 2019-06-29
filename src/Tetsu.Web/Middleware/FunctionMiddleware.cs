using System;
using Tetsu.Web.Http;

namespace Tetsu.Web.Middleware {
    public class FunctionMiddleware : IMiddleware
    {
        private readonly Action<HttpContext> action;

        public FunctionMiddleware(Action<HttpContext> action)
        {
            this.action = action;
        }

        public void Process(HttpContext context)
        {
            action(context);
        }
    }
}