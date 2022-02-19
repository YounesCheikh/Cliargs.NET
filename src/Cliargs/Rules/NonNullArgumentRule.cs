using System;
namespace Cliargs.Rules
{
	public class NonNullArgumentRule: ICliArgsValidationRule
	{
		public NonNullArgumentRule()
		{
		}

        public string GetValidationError()
        {
            return "Value required and must not be null or empty.";
        }
    }
}

