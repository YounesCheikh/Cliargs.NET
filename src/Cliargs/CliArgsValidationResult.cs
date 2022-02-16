using System;
namespace Cliargs
{
	public class CliArgsValidationResult: ICliArgsValidationResult
	{
		public CliArgsValidationResult(ICliArgsValidationRule rule, bool isValid)
		{
			this.Rule = rule;
			this.IsValid = IsValid;
		}

        public ICliArgsValidationRule Rule { get; private set; }

        public bool IsValid { get; private set; }
    }
}

