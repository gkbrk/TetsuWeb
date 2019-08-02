using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Tetsu.Web.Http {
    public class Response {
        private IList<(string, string)> headers = new List<(string, string)>();
        public int StatusCode { get; set; }
        public byte[] Content { get; set; }
        public string TextContent {
            get => Encoding.UTF8.GetString(Content);
            set => Content = Encoding.UTF8.GetBytes(value);
        }

        public void AddHeader(string key, string value) {
            headers.Add((key, value));
        }

        public void SetHeader(string key, string value) {
            var toRemove = headers
                .Where(x => x.Item1 == key)
                .ToList();

            toRemove.ForEach(x => headers.Remove(x));

            AddHeader(key, value);
        }

        public async Task Serialize(Stream stream, HttpContext context) {
            var sb = new StringBuilder($"HTTP/1.1 {StatusCode} Lel\r\n" +
                                       $"Content-Length: {Content.LongLength}\r\n");

            foreach (var header in headers)
            {
                sb.Append($"{header.Item1}: {header.Item2}\r\n");
            }

            sb.Append("\r\n");
            await stream.WriteAsync(Encoding.UTF8.GetBytes(sb.ToString()), 0, sb.Length);
            await stream.WriteAsync(Content, 0, Content.Length);
        }
    }
}
