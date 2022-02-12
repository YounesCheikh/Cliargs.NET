using System;
namespace Cliargs
{
	public class CLIArguments
	{
		private readonly List<CliArgumentContext> argumentContexts = new List<CliArgumentContext>();

		public CLIArguments()
		{
		}

		public void AddCliArgument<T>(CliArgumentContext<T> argumentContext)
        {
			argumentContexts.Add(argumentContext);
        }

		public static CLIArguments New()
        {
			return new CLIArguments();
		}
	}
}

