using Tetsu.Web.Http;

namespace Tetsu.Web.Router {
    public class ExactMatch : IRouteMatcher {
        private readonly string path;
        private readonly string method;

        public ExactMatch(string path) {
            this.path = path;
        }

        public ExactMatch(string method, string path) {
            this.method = method;
            this.path = path;
        }


        public bool IsMatch(Request req) => req.Uri == this.path;
    }
}
