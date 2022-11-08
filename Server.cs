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

			HandleRequest(ctx);

			Log(ctx);
		}

	}

	private void HandleRequest(HttpListenerContext ctx)
	{
		var httpMethod = ctx.Request.HttpMethod;
		var message = $"You are using {httpMethod} request method";

		Response.String(ctx, message);

	}





	private void Log(HttpListenerContext ctx)
	{
		var time = DateTime.Now;
		Console.WriteLine($"{time} [{ctx.Response.StatusCode}] {ctx.Request.HttpMethod} {ctx.Request.Url} ");
	}




}