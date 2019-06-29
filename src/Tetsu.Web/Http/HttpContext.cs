namespace Tetsu.Web.Http {
    public class HttpContext {
        public Request Request { get; set; }
        public Response Response { get; set; }
        public bool StopProcessing { get; set; }
    }
}