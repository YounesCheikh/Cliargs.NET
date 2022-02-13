using System;
namespace Cliargs
{
	public class CLIArguments
	{
		private readonly List<CliArgumentContext> argumentContexts = new List<CliArgumentContext>();

		private CLIArguments()
		{
		}

		public void AddCliArgument<T>(CliArgumentContext<T> argumentContext)
        {
			argumentContexts.Add(argumentContext);
        }

		public static CLIArguments New<TConfiguration>() where TConfiguration : IArgsConfiguration, new()
		{
			IArgsConfiguration configuration = new TConfiguration();
			var args = new CLIArguments();
			configuration.Configure(args);
			return args;
		}

		public void Validate()
        {
			var args =  Environment.GetCommandLineArgs();
			// TODO : Continue here ! 
		}
	}
}

