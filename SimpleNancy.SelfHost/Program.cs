using System;
using Nancy.Hosting.Self;

namespace SimpleNancy.SelfHost
{
	class Program
	{
		static void Main()
		{
			try
			{
				using (var host = new NancyHost(new Uri("http://localhost:1234")))
				{
					Console.WriteLine("host start");
					host.Start();
					Console.WriteLine("host started");
					while (Console.ReadKey(true).Key != ConsoleKey.Escape)
					{
						
					}
					Console.WriteLine("App closing");
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}
		}
	}
}
