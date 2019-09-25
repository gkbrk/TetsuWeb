# TetsuWeb

TetsuWeb is a C# microframework for building websites, APIs and microservices.

## Example

```csharp
using Tetsu.Web;

namespace Example {
    public class Program {
        public static void Main() {
            var server = new Server();

            server.Handle("/greet", ctx =>
                ctx.Response.TextContent = "Hello, World!");

            server.Listen("0.0.0.0", 1234).Wait();
        }
    }
}
```

## License

This work is published under the MIT License. The full license
text can be found in the LICENSE file.