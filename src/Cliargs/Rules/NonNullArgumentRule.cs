using System;
namespace Cliargs
{
	public class NonNullArgumentRule: ICliArgsValidationRule
	{
		public NonNullArgumentRule()
		{
		}

        public bool? Result { get; internal set; }

        public string GetValidationError()
        {
            return "Value required and must not be null or empty.";
        }
    }
}

