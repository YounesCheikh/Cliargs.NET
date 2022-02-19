using System;
using System.Text;

namespace Cliargs
{
	/// <summary>
    /// Argument value rules Validation result 
    /// </summary>
	public class CliArgsValidationResult: ICliArgsValidationResult
	{
		/// <summary>
        /// Create a new instnace
        /// </summary>
        /// <param name="rule">The rule</param>
        /// <param name="info">The argument info</param>
        /// <param name="isValid">If the value is valid after applied the rule</param>
		public CliArgsValidationResult(ICliArgsValidationRule rule, CliArgsInfo info, bool isValid)
		{
			ArgumentNullException.ThrowIfNull(rule);
			ArgumentNullException.ThrowIfNull(info);

			_rule = rule;
			_info = info;
			IsValid = isValid;
		}

		private ICliArgsValidationRule _rule;
		private CliArgsInfo _info;

		/// <summary>
        /// Indicates if the execution of the validation rules has succeeded.
        /// </summary>
        public bool IsValid { get; private set; }

		/// <summary>
        /// The usage example of the given argument
        /// </summary>
		public string Usage => _info.Usage;

		/// <summary>
        /// The rule validation rule
        /// </summary>
		public string ValidationError => _rule.GetValidationError();

		/// <summary>
        /// The argument name 
        /// </summary>
		public string ArgName => _info.Name;

		/// <summary>
        /// The validation rule name
        /// </summary>
		public string RuleName => _rule.GetType().GetNameWithoutGenericArity();

		/// <summary>
		/// The report of validation result
		/// </summary>
		/// <returns>The result report</returns>
		public string GetReport()
        {
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"Error: Failed to validate arugment '{ArgName}' with rule '{RuleName}'");
			stringBuilder.AppendLine($"\"{ValidationError}\"");
			stringBuilder.AppendLine($"Example usage: ");
			stringBuilder.AppendLine(Usage);
			return stringBuilder.ToString();
		}
    }
}

