using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
public class Server
{
	private int port;
	private HttpListener _listener;

	public Server(int port)
	{
		this.port = port;
	}

	public void Run()
	{
		_listener = new HttpListener();
		_listener.Prefixes.Add($"http://localhost:{Convert.ToString(port)}/");
		_listener.Start();

		Console.WriteLine($"Listening to localhost:{port} ...");

		Receive();
	}

	private void Stop()
	{
		_listener.Stop();
	}

	private void Receive()
	{
		while (true)
		{
			HttpListenerContext ctx = _listener.GetContext();
			HttpListenerRequest req = ctx.Request;

			// req.Headers.Add("User-Agent", "C# Program");
			// using HttpListenerResponse res = ctx.Response;

			Person bob = new Person("bob", 31);

			Response.stringResponse(ctx, $"Hello {bob.name}, so you are {bob.age} years old?");



			Log(ctx);
		}

	}

	private void HandleRequest(HttpListenerContext ctx)
	{


	}





	private void Log(HttpListenerContext ctx)
	{
		Console.WriteLine($"[{ctx.Response.StatusCode}] {ctx.Request.Url}");
	}




}