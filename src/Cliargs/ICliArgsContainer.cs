using System;
namespace Cliargs
{
	public interface ICliArgsContainer
	{
		IReadOnlyDictionary<string, CliArg> CliArgs { get; }

		void Register(CliArg arg);

		T? GetValue<T>(string argName);

		object? GetValue(string argName);

		CliArgsFormat Format { get; }

		IArgumentsProvider ArgumentsProvider { get; set; } 
	} 
}

