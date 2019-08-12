#!t/cs-script

using Tetsu.Web.Router;
using Tetsu.Web.Http;

void IsMatch(string route) {
    var router = new ExactMatch(route);
    var req = new Request
    {
        Uri = route
    };

    Ok(router.IsMatch(req));
}

IsMatch("");
IsMatch("/");
IsMatch("/test");
IsMatch("/test?q=1");
IsMatch("test");

DoneTesting();
