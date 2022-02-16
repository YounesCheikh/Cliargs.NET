using System;
namespace Cliargs
{
	public interface ICliArgsContainer
	{
		ICliArgsRepository CliArgsRepository { get; }

		void Register(CliArgsInfo info, ICliArgsValidationContext context);

		T? GetValue<T>(string argName);

		CliArgsFormat Format { get; }
	}
}

