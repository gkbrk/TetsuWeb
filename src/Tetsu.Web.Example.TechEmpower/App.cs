using System;
using Newtonsoft.Json;

namespace Tetsu.Web.Example.TechEmpower {
    public class App {
        public static void Main() {
            var server = new Server();

            server.Handle("/plaintext", ctx =>
                ctx.Response.TextContent = "Hello, World!");
            
            server.Handle("/json", ctx => {
                ctx.Response.SetHeader("Content-Type", "application/json");
                ctx.Response.TextContent = JsonConvert.SerializeObject(new {
                    message = "Hello, World!"
                });
            });

            server.Listen("127.0.0.1", 1234).Wait();
        }
    }
}