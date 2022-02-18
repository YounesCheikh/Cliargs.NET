using System;
namespace Cliargs
{
	public abstract class CliArgsValidationRule<T>: ICliArgsValidationRule<T>
	{
		public CliArgsValidationRule()
		{
		}

        public bool? Result { get; internal set; }

        public abstract string GetValidationError();

        public abstract bool IsValid(T value);
    }
}

