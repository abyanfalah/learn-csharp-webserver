using System.Net.Http;
using System.Net;


using var listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8000");

listener.Start();

while (true)
{
	HttpListenerContext ctx = listener.GetContext();
	HttpListenerRequest req = ctx.Request;


}