using System;
namespace Cliargs
{
	public interface ICliArgsValidationContext
    {

    }

	public interface ICliArgsValidationContext<T> : ICliArgsValidationContext
	{
		bool IsValid(T value);

		IEnumerable<ICliArgsValidationResult> Validate(T value, string inputValue);

		void AddRule(ICliArgsValidationRule<T> rule);
	}
}

