using System;
namespace Cliargs
{
	public interface ICliArgsValidationRule
	{
		string GetValidationError();
	}

	public interface ICliArgsValidationRule<T> : ICliArgsValidationRule
	{
		bool IsValid(T value);
	}
}

