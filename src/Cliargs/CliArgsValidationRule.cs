using System;
namespace Cliargs
{
	public abstract class CliArgsValidationRule<T>: ICliArgsValidationRule<T>
	{
		public CliArgsValidationRule()
		{
		}

        public abstract string GetValidationError();

        public abstract bool IsValid(T value);
    }
}

