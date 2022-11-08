using System.Text;
using System.Net;


Console.Clear();

using var listener = new HttpListener();
const string host = "http://localhost";
const string port = "8000";
const string uri = host + ":" + port + "/";
listener.Prefixes.Add(uri);

listener.Start();

Console.WriteLine($"listeting to port {port}");

while (true)
{
	HttpListenerContext ctx = listener.GetContext();
	HttpListenerRequest req = ctx.Request;

	using HttpListenerResponse res = ctx.Response;
	// res.Headers.Set("Content-type", "application/json");
	res.Headers.Set("Content-type", "text/plain");

	res.StatusCode = (int)HttpStatusCode.OK;
	res.StatusDescription = "OK";

	req.Headers.Add("User-Agent", "C# Program");
	string? ua = req.Headers.Get("User-Agent");

	string data = ua ?? "Unknown";
	byte[] buffer = Encoding.UTF8.GetBytes(data);
	res.ContentLength64 = buffer.Length;

	using Stream ros = res.OutputStream;
	ros.Write(buffer, 0, buffer.Length);


	log(ctx);
}

void log(HttpListenerContext ctx)
{
	Console.Write($"[{ctx.Response.StatusCode}]  ");
	Console.WriteLine(ctx.Request.Url);
}