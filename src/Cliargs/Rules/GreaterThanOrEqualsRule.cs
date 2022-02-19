using System;
namespace Cliargs.Rules
{
    public class GreaterThanOrEqualsRule<T> : CliArgsValidationRule<T> where T : IComparable

    {
        T _value;
        public GreaterThanOrEqualsRule(T value)
        {
            _value = value;
        }
        public override string GetValidationError()
        {
            return $"The given value must be greater than or equals to {_value}";
        }

        public override bool IsValid(T value)
        {
            return value.CompareTo(_value) >= 0;
        }
    }
}

