using System;
using System.Threading;
using Nancy.Hosting.Self;

namespace SimpleNancy.SelfHost
{
	class Program
	{
		/// <summary>
		/// Mesos config shennanigans
		/// </summary>
		///
		class MesosConfiguration 
		{
			public string TASK_HOST {
				get;
				set;
			}

			public string PORT0 {
				get;
				set;
			}

			public string INSTANCE_NO {
				get;
				set;
			}
		}
		static readonly ManualResetEvent ResetEvent = new ManualResetEvent(false);
	
		static void Main()
		{
			try
			{
				var mesosConfig  = GetImportantMesosVariables();
				var uri =new Uri(String.Format("http://{0}:{1}",mesosConfig.TASK_HOST,mesosConfig.PORT0)); 
				Console.WriteLine(uri.OriginalString);
				using (var host = new NancyHost(uri))
				{
					Console.WriteLine("host starting on: ", uri.OriginalString);
					host.Start();
					Console.WriteLine("host started");
					ResetEvent.WaitOne();
					Console.WriteLine("app closing");
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}
		}


		static MesosConfiguration GetImportantMesosVariables(){
			var host = "localhost";
			var instanceId = "1";
			var port0 = "1234";

			var envHost  = Environment.GetEnvironmentVariable ("TASK_HOST");
			host = String.IsNullOrEmpty (envHost) ? host : envHost;

			var envPort0 = Environment.GetEnvironmentVariable ("PORT0");
			Console.WriteLine(Environment.GetEnvironmentVariable("PORT0"));
			port0 = String.IsNullOrEmpty (envPort0) ? port0 : envPort0;
			Console.WriteLine(port0);

			var envInstanceId = Environment.GetEnvironmentVariable ("INSTANCE_NO");
			instanceId = String.IsNullOrEmpty (envInstanceId) ? instanceId : envInstanceId;

			return new MesosConfiguration{TASK_HOST=host,PORT0=port0,INSTANCE_NO=instanceId};
		}
	}
}
