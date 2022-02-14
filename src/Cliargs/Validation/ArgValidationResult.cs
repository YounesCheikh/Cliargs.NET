using System;
namespace Cliargs.Validation
{
	public class ArgValidationResult
	{
		public ArgValidationResult(ArgumentInfo info, IValidationRule validationRule, string argInputValue, bool isValid)
		{
			this.Info = info;
			this.Rule = validationRule;
			this.ArgumentInputValue = argInputValue;
			this.IsValid = isValid;
		}

		public ArgumentInfo Info { get; private set; }

		/// <summary>
        /// The argument 
        /// </summary>
        public IValidationRule Rule { get; private set; }


		/// <summary>
        /// The argument value as entered by user.
        /// </summary>
		public string ArgumentInputValue { get; private set; }


		/// <summary>
        /// The validation result, true if all the validation rules are succeeded
        /// Otherwise false. 
        /// </summary>
		public bool IsValid { get; set; }
    }
}

