using System;
namespace Cliargs
{
	public interface IArgumentsProvider
	{
		string[] GetCommandLineArgs();
	}
}

