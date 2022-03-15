using System.Text.RegularExpressions;

namespace Cliargs.Rules
{
    public class RegexRule : CliArgsValidationRule<string>
    {
        private string _pattern;
        private RegexOptions _regexOptions = RegexOptions.IgnoreCase;
        public RegexRule(string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            _pattern = pattern;
        }

        string _validationError {get;set;} = "Value doesn't meet with the defined regex.";

        public override string GetValidationError()
        {
            return _validationError;
        }

        public override bool IsValid(string value)
        {
            return Regex.IsMatch(value, _pattern, _regexOptions);
        }

        public RegexRule WithValidationError(string validationError) {
            this._validationError = validationError;
            return this;
        }

        public static RegexRule WithPattern(string pattern, RegexOptions options = RegexOptions.IgnoreCase) {
            return new RegexRule(pattern, options);
        }
    }
}