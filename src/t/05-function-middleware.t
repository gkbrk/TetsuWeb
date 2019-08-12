#!t/cs-script

using Tetsu.Web.Http;
using Tetsu.Web.Middleware;

var middleware = new FunctionMiddleware(ctx => {
    Ok(ctx != null, "HTTP Context is not null");
    Ok(ctx?.Request != null, "Request is not null");
    Ok(ctx?.Response != null, "Response is not null");
});

var context = new HttpContext {
    Request = new Request(),
    Response = new Response()
};

middleware.Process(context);

DoneTesting();
