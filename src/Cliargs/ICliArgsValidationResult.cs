using System;
namespace Cliargs
{
	public interface ICliArgsValidationResult
	{
		string RuleName { get; }
				
		string Usage { get; }

		string ValidationError { get; }

		string ArgName { get; }

		bool IsValid { get; }
	}
}

