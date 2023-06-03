using System.Net;
using System.Text;

HttpListener server = new();
server.Prefixes.Add("https://localhost:8888/");
server.Start();

var context = await server.GetContextAsync();
var response = context.Response;

string htmlResponse = @"<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Document</title>
</head>
<body>
    <h1>Hello world</h1>
</body>
</html>";

byte[] buffer = Encoding.UTF8.GetBytes(htmlResponse);
response.ContentLength64 = buffer.Length;
using Stream output = response.OutputStream;

await output.WriteAsync(buffer);
await output.FlushAsync();

Console.WriteLine("Request send");

server.Stop();