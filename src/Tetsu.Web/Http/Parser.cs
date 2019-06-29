using System.IO;
using System.Threading.Tasks;
using System.Text;

namespace Tetsu.Web.Http
{
    public static class Parser
    {
        public static async Task<Request> ParseRequest(Stream stream)
        {
            var read = new StreamReader(stream);
            var reqLine = await read.ReadLineAsync();

            var parts = reqLine.Split(' ');

            return new Request
            {
                Method = parts[0],
                Uri = parts[1],
                Version = parts[2],
            };
        }

        public static Request ParseRequest(string req) =>
           ParseRequest(new MemoryStream(Encoding.UTF8.GetBytes(req))).Result;
    }
}
