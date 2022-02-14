using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cliargs.Conversion;

namespace Cliargs.Validation
{
    public class ArgValidationContext<T>
    {
        private readonly List<ValidationRule<T>> _validationRules = new List<ValidationRule<T>>();

        private readonly ArgumentInfo info;

        private ArgValidationContext(ArgumentInfo info)
        {
            this.info = info;
        }

        public bool IsValid(T value) => this._validationRules.All(r=> r.IsValid(value));

        public IEnumerable<ArgValidationResult> Validate(T value, string inputValue)
        {
            foreach (var validationRule in _validationRules)
            {
               if(validationRule.IsValid(value))
                {
                    yield return new ArgValidationResult(info, validationRule, inputValue, true);
                }
            }
        }

        public void AddRule(ValidationRule<T> rule) 
        {
            _validationRules.Add(rule);
        }

        public static ArgValidationContext<T> New(ArgumentInfo info)
        {
            return new ArgValidationContext<T>(info);
        }
    }
}