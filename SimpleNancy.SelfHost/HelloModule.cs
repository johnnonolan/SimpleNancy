namespace SimpleNancy.SelfHost
{
	using Nancy;

	public class HelloModule : NancyModule
	{
		public HelloModule()
		{
			Get["/"] = _ => "Hello I'm a self hosting Nancy process hopefully from inside a docker container running on mono!";
		}

	}
}
