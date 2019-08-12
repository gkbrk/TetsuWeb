#!t/cs-script

using Tetsu.Web.Http;

void TestMethod(string reqStr, string method) {
    var req = Parser.ParseRequest($"{reqStr}\r\n\r\n");
    Ok(req.Method == method);
}

TestMethod("DELETE / HTTP/1.1", "DELETE");
TestMethod("GET / HTTP/1.1", "GET");
TestMethod("POST / HTTP/1.1", "POST");
TestMethod("OPTIONS / HTTP/1.1", "OPTIONS");

DoneTesting();
