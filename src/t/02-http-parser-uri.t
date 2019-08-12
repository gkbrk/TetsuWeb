#!t/cs-script

using Tetsu.Web.Http;

void TestUri(string reqStr, string uri) {
    var req = Parser.ParseRequest($"{reqStr}\r\n\r\n");
    Ok(req.Uri == uri);
}

TestUri("GET / HTTP/1.1", "/");
TestUri("GET /test1 HTTP/1.1", "/test1");
TestUri("POST / HTTP/1.1", "/");
TestUri("POST /test2 HTTP/1.1", "/test2");

DoneTesting();
