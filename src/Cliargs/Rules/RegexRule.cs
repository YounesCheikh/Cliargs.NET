using System;
using System.Text.RegularExpressions;

namespace Cliargs.Rules
{
    public class RegexRule : CliArgsValidationRule<string>
    {
        Regex _regex;

        string _validationError {get;set;} = "Value doesn't meet with the defined regex.";

        /// <summary>
        /// Create new instance with pattern
        /// </summary>
        /// <param name="pattern">The regex pattern</param>
        /// <exception cref="CliArgsException">If the given pattern is invalid for Regex</exception>
        public RegexRule(string pattern)
        {
            try{
                _regex = new Regex(pattern);
            }catch(Exception exception){
                throw new CliArgsException("The pattern provided is not valid pattern for regular expression", exception);
            }
        }

        /// <summary>
        /// Create a new instance with a pattern and Regex options
        /// </summary>
        /// <param name="pattern">The regex pattern</param>
        /// <param name="options">The regex options</param>
        /// <exception cref="CliArgsException">If the given pattern is invalid for Regex</exception>
        public RegexRule(string pattern, RegexOptions options)
        {
            try{
                _regex = new Regex(pattern, options);
            }catch(Exception exception){
                throw new CliArgsException("The pattern provided is not valid pattern for regular expression", exception);
            }
        }

        /// <summary>
        /// Get the default validation error
        /// </summary>
        /// <returns></returns>
        public override string GetValidationError()
        {
            return _validationError;
        }

        /// <summary>
        /// Validate a given value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>True if the value validated sucessfully, otherwise false</returns>
        public override bool IsValid(string value)
        {
            return _regex.IsMatch(value);
        }

        /// <summary>
        /// Set a custom validation error 
        /// </summary>
        /// <param name="validationError">The custom validation error</param>
        /// <returns>The rule instance</returns>
        public RegexRule WithValidationError(string validationError) {
            this._validationError = validationError;
            return this;
        }

        /// <summary>
        /// Create a new instance with a pattern and Regex options
        /// </summary>
        /// <param name="pattern">The regex pattern</param>
        /// <param name="options">The regex options</param>
        /// <exception cref="CliArgsException">If the given pattern is invalid for Regex</exception>
        public static RegexRule WithPattern(string pattern, RegexOptions options)
        {
            return new RegexRule(pattern, options);
        }

        /// <summary>
        /// Create new instance with pattern
        /// </summary>
        /// <param name="pattern">The regex pattern</param>
        /// <exception cref="CliArgsException">If the given pattern is invalid for Regex</exception>
        public static RegexRule WithPattern(string pattern)
        {
            return new RegexRule(pattern);
        }
    }
}