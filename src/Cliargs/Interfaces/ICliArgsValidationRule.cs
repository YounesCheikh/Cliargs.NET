using System;
namespace Cliargs
{
	/// <summary>
    /// The command line interface arguments validation rule
    /// </summary>
	public interface ICliArgsValidationRule
	{
		/// <summary>
        /// Default validation error
        /// </summary>
        /// <returns></returns>
		string GetValidationError();
	}

	/// <summary>
    /// The command line interface arguments validation rule
    /// </summary>
    /// <typeparam name="T">The validation rule type</typeparam>
	public interface ICliArgsValidationRule<T> : ICliArgsValidationRule
	{
		/// <summary>
        /// Indicates if the validation process succeeded
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>True if the value is valid, otheriwse false.</returns>
		bool IsValid(T value);
	}
}

