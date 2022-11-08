class Program
{
	public static void Main()
	{
		Console.Clear();
		var server = new Server(8000);
		server.Run();
	}
}