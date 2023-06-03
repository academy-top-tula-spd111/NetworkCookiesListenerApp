using System.Net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) => 
{
    context.Response.Cookies.Append("name", "Leopold");
    context.Response.Cookies.Append("email", "leo@gmail.com");
});

app.MapGet("/user", (HttpContext context) =>
{
    context.Request.Cookies.TryGetValue("name", out var name);
    context.Request.Cookies.TryGetValue("email", out var email);

    context.Response.Cookies.Append("name", name);
    context.Response.Cookies.Append("email", email);

    return $"name: {name}, email: {email}";
});

app.Run();
