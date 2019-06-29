using System;
using System.Threading.Tasks;
using Tetsu.Web.Http;
using Tetsu.Web.Middleware;

namespace Tetsu.Web
{
    public interface IServer
    {
        Task Listen(string host, int port);
        void AddMiddleware(IMiddleware middleware);
        void AddMiddleware(Action<HttpContext> action);
    }
}
