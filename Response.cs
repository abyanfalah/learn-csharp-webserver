using System.Text;
using System.Net;

class Response
{
	public static void String(HttpListenerContext ctx, string data)
	{
		ctx.Request.Headers.Add("Content-type", "text/plain");

		byte[] buffer = Encoding.UTF8.GetBytes(data);

		using Stream ros = ctx.Response.OutputStream;
		ros.Write(buffer);
	}

	// public static void Json(HttpListenerContext ctx, object data)
	// {
	// 	ctx.Request.Headers.Add("Content-type", "text/plain");

	// 	byte[] buffer = Encoding.UTF8.GetBytes(data);

	// 	using Stream ros = ctx.Response.OutputStream;
	// 	ros.Write(buffer);
	// }
}