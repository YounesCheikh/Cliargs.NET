using System;
namespace Cliargs
{
	public class CliArgsValidationContext<T>: ICliArgsValidationContext<T>
	{
		IList<ICliArgsValidationRule<T>> _validationRules = new List<ICliArgsValidationRule<T>>();

		public CliArgsValidationContext()
		{
		}


		public bool IsValid(T value) => this._validationRules.All(r => r.IsValid(value));

        public IEnumerable<ICliArgsValidationResult> Validate(T value, string inputValue)
        {
            foreach (var validationRule in _validationRules)
            {
                yield return new CliArgsValidationResult(validationRule, validationRule.IsValid(value));
            }
        }

        public void AddRule(ICliArgsValidationRule<T> rule)
        {
            _validationRules.Add(rule);
        }
    }
}

