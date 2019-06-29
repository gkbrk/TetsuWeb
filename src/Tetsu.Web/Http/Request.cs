using System;
using System.Collections.Generic;

namespace Tetsu.Web.Http
{
    public class Request
    {
        public string Method { get; set; }
        public string Uri { get; set; }
        public string Version { get; set; }
        public IList<Tuple<string, string>> Headers { get; set; }
    }
}
