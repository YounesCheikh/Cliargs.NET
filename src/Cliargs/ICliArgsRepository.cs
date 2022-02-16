using System;
namespace Cliargs
{
	public interface ICliArgsRepository
	{
		IReadOnlyDictionary<string, CliArgsInfo> CliArgsInfos { get; }

		IReadOnlyDictionary<string, ICliArgsValidationContext> CliArgsValidationContexts { get; }

		IReadOnlyDictionary<string, CliArg> CliArgs { get; }

		void AddCliArgsInfo(CliArgsInfo info);

		void AddCliArgsValidationContext(string name, ICliArgsValidationContext validationContext);
	}
}

