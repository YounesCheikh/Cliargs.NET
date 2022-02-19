using System;
namespace Cliargs
{
	/// <summary>
    /// Command Line interface arguments validation result 
    /// </summary>
	public interface ICliArgsValidationResult
	{
		/// <summary>
        /// The rule name
        /// </summary>
		string RuleName { get; }

		/// <summary>
        /// Sample usage example
        /// </summary>
		string Usage { get; }

		/// <summary>
        /// The rule default validation error
        /// </summary>
		string ValidationError { get; }

		/// <summary>
        /// The argument name
        /// </summary>
		string ArgName { get; }

		/// <summary>
        /// The validation result
        /// </summary>
		bool IsValid { get; }
	}
}

