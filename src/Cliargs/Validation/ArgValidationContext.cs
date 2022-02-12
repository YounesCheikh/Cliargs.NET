using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliargs.Validation
{
    public class ArgValidationContext<T>
    {
        private readonly List<ValidationRule<T>> _validationRules = new List<ValidationRule<T>>();

        public bool IsValid(T value) => this._validationRules.All(r=> r.IsValid(value));

        public void AddRule(ValidationRule<T> rule) 
        {
            _validationRules.Add(rule);
        }

        public static ArgValidationContext<T> New()
        {
            return new ArgValidationContext<T>();
        }
    }
}