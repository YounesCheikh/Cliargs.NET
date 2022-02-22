using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliargs.Rules
{
    public class ConditionalRule<T> : CliArgsValidationRule<T>
    {
        Func<T, bool> _func;
        public ConditionalRule(Func<T, bool> func)
        {
            _func = func;
        }

        string _validationError {get;set;} = "Value doesn't meet with the defined custom condition.";

        public override string GetValidationError()
        {
             return _validationError;
        }

        public override bool IsValid(T value)
        {
            return _func(value);
        }

        public ConditionalRule<T> WithValidationError(string validationError) {
            this._validationError = validationError;
            return this;
        }
        public static ConditionalRule<T> WithCondition(Func<T, bool> func) {
            return new ConditionalRule<T>(func);
        }
    }
}