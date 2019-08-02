using Xunit;
using Tetsu.Web.Http;
using System.Text;
using System.IO;

namespace Tetsu.Web.Tests.Http
{
    public class ParserTest
    {
        [Theory]
        [InlineData("DELETE / HTTP/1.1", "DELETE")]
        [InlineData("GET / HTTP/1.1", "GET")]
        [InlineData("HEAD / HTTP/1.1", "HEAD")]
        [InlineData("POST / HTTP/1.1", "POST")]
        [InlineData("PUT / HTTP/1.1", "PUT")]
        public void TestParser_Method(string reqStr, string method)
        {
            var req = Parser.ParseRequest($"{reqStr}\r\n\r\n");

            Assert.Equal(method, req.Method);
        }

        [Theory]
        [InlineData("GET / HTTP/1.1", "/")]
        [InlineData("GET /test1 HTTP/1.1", "/test1")]
        [InlineData("POST / HTTP/1.1", "/")]
        [InlineData("POST /test1 HTTP/1.1", "/test1")]
        public void TestParser_Uri(string reqStr, string uri)
        {
            var req = Parser.ParseRequest($"{reqStr}\r\n\r\n");

            Assert.Equal(uri, req.Uri);
        }

    }
}
