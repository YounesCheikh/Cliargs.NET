using System;
namespace Cliargs.Extensions
{
	public static class CLIArgumentsExtensions
	{
		public static CLIArguments WithArgument<T>(this CLIArguments args, CliArgumentContext<T> argumentContext)
        {
			args.AddCliArgument(argumentContext);
			return args;
        }
	}
}

