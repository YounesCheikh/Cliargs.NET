using System;
namespace Cliargs
{
	/// <summary>
    /// Validation rule base class
    /// </summary>
    /// <typeparam name="T">The type of the target argument</typeparam>
	public abstract class CliArgsValidationRule<T>: ICliArgsValidationRule<T>
	{
		public CliArgsValidationRule()
		{
		}

        /// <summary>
        /// Get the validation rule default error
        /// </summary>
        /// <returns>The default error message</returns>
        public abstract string GetValidationError();

        /// <summary>
        /// Check if the value is valid with rule
        /// </summary>
        /// <param name="value">The argument value</param>
        /// <returns>True if the value is valid, otherwise false.</returns>
        public abstract bool IsValid(T value);
    }
}

