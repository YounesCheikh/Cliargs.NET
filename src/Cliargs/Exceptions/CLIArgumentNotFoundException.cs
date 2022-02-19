using System;
namespace Cliargs
{
	public class CLIArgumentNotFoundException : CliArgsException
	{
		public string ArgumentName { get; }
		public CLIArgumentNotFoundException(string name) : base("Command Line Argument Not found")
		{
			this.ArgumentName = name;
		}
	}
}

