using System.Text;
using System.Net;

class Response
{
	public static void stringResponse(HttpListenerContext ctx, string data)
	{
		byte[] buffer = Encoding.UTF8.GetBytes(data);

		using Stream ros = ctx.Response.OutputStream;
		ros.Write(buffer);
	}
}