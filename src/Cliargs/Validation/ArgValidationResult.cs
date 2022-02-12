using System;
namespace Cliargs.Validation
{
	public class ArgValidationResult
	{
		public ArgValidationResult(ArgumentInfo info, string argInputValue, bool isValid)
		{
			this.argumentInfo = info;
			this.ArgumentInputValue = argInputValue;
			this.IsValid = isValid;
		}

		/// <summary>
        /// The argument 
        /// </summary>
        public ArgumentInfo argumentInfo { get; private set; }


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

