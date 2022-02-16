using System;
namespace Cliargs
{
	public interface ICliArgsValidationResult
	{
		ICliArgsValidationRule Rule { get; }

		bool IsValid { get; }
	}
}

