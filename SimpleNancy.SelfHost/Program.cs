using System;
using Nancy.Hosting.Self;

namespace SimpleNancy.SelfHost
{
	class Program
	{
		static void Main()
		{
			using (var host = new NancyHost(new Uri("http://localhost:1234")))
			{
				host.Start();
				Console.ReadLine();
			}

		}
	}
}
