using System;
namespace Cliargs
{
	public interface ICliArgsContainer
	{
		ICliArgsRepository CliArgsRepository { get; }

		void Register(CliArg arg);

		T? GetValue<T>(string argName);

		CliArgsFormat Format { get; }
	}
}

