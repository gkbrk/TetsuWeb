using Xunit;
using Tetsu.Web.Http;
using System.Text;
using System.IO;

namespace Tetsu.Web.Tests.Http
{
    public class ParserTest
    {
        [Theory]
        [InlineData("DELETE / HTTP/1.1\r\n", "DELETE")]
        [InlineData("GET / HTTP/1.1\r\n", "GET")]
        [InlineData("HEAD / HTTP/1.1\r\n", "HEAD")]
        [InlineData("POST / HTTP/1.1\r\n", "POST")]
        [InlineData("PUT / HTTP/1.1\r\n", "PUT")]
        public void TestParser_Method(string reqStr, string method)
        {
            var req = Parser.ParseRequest(reqStr);

            Assert.Equal(method, req.Method);
        }

        [Theory]
        [InlineData("GET / HTTP/1.1\r\n", "/")]
        [InlineData("GET /test1 HTTP/1.1\r\n", "/test1")]
        [InlineData("POST / HTTP/1.1\r\n", "/")]
        [InlineData("POST /test1 HTTP/1.1\r\n", "/test1")]
        public void TestParser_Uri(string reqStr, string uri)
        {
            var req = Parser.ParseRequest(reqStr);

            Assert.Equal(uri, req.Uri);
        }

    }
}
