using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Tetsu.Web.Http;
using Tetsu.Web.Middleware;
using Tetsu.Web.Router;

namespace Tetsu.Web
{
    public class Server : IServer
    {
        private IList<IMiddleware> middlewares;
        private readonly IRouter router;

        public Server()
        {
            middlewares = new List<IMiddleware>();
            router = new OrderedRouter();
        }

        public void Handle(string route, Action<HttpContext> action) =>
            router.AddRoute(new ExactMatch(route), new FunctionMiddleware(action));

        public void Handle(string route, Action<Request, Response> action) =>
            Handle(route, a => action(a.Request, a.Response));

        public void AddMiddleware(IMiddleware middleware) =>
            middlewares.Add(middleware);

        public void AddMiddleware(Action<HttpContext> action) =>
            middlewares.Add(new FunctionMiddleware(action));

        public async Task Listen(string host, int port)
        {
            middlewares.Add(router);
            var ip = IPAddress.Parse(host);
            var listener = new TcpListener(ip, port);

            listener.Start();
            System.Console.WriteLine($"Listening on {ip}:{port}...");

            while (true)
            {
                var sock = await listener.AcceptTcpClientAsync();
                var stream = sock.GetStream();
                var reader = new StreamReader(stream);

                var _ = Task.Run(async () => {
                    try {
                        while (true) {
                            var context = new HttpContext
                            {
                                Request = await Parser.ParseRequest(reader),
                                Response = new Response()
                            };

                            context.Response.StatusCode = 200;
                            context.Response.Content = new byte[] { };
                            context.Response.SetHeader("Content-Type", "text/plain");
                            context.Response.SetHeader("Server", "Tetsu");

                            foreach (var middleware in middlewares)
                            {
                                middleware.Process(context);

                                if (context.StopProcessing) break;
                            }

                            await context.Response.Serialize(stream, context);
                        }
                    } catch (Exception) {}
                });
            }
        }
    }
}
