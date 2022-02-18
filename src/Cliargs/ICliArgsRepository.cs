using System;
namespace Cliargs
{
	public interface ICliArgsRepository
	{
		IReadOnlyDictionary<string, CliArg> CliArgs { get; }

		void AddCliArg(CliArg arg);
	}
}

