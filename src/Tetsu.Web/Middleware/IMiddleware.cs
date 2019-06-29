using Tetsu.Web.Http;

namespace Tetsu.Web.Middleware {
    public interface IMiddleware {
        void Process(HttpContext context);
    }
}