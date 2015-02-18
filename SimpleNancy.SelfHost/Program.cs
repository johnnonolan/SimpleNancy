using System;
using System.Threading;
using Nancy.Hosting.Self;

namespace SimpleNancy.SelfHost
{
	class Program
	{
		static readonly ManualResetEvent ResetEvent = new ManualResetEvent(false);
		static void Main()
		{
			try
			{
				using (var host = new NancyHost(new Uri("http://localhost:1234")))
				{
					Console.WriteLine("host start");
					host.Start();
					Console.WriteLine("host started");
					ResetEvent.WaitOne();
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
