using System;
namespace Cliargs
{
	public interface ICliArgsValidationRule
	{
		string GetValidationError();
		bool? Result { get; }
	}

	public interface ICliArgsValidationRule<T> : ICliArgsValidationRule
	{
		bool IsValid(T value);
	}
}

