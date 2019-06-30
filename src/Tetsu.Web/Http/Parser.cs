using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;

namespace Tetsu.Web.Http {
    public static class Parser {
        public static async Task<Request> ParseRequest(Stream stream) {
            var read = new StreamReader(stream);
            var reqLine = await read.ReadLineAsync();
            var reqParts = reqLine.Split(' ');

            var headers = new List<(string, string)>();

            while (true) {
                var line = await read.ReadLineAsync();
                if (line.Trim() == "") break;

                var parts = line.Split(':');
                headers.Add((parts[0].Trim(), parts[1].Trim()));
            }

            return new Request {
                Method = reqParts[0],
                Uri = reqParts[1],
                Version = reqParts[2],
                Headers = headers,
            };
        }

        public static Request ParseRequest(string req) =>
           ParseRequest(new MemoryStream(Encoding.UTF8.GetBytes(req))).Result;
    }
}
