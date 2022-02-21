using System;
namespace Cliargs.Rules
{
    public class LessThanOrEqualsRule<T> : CliArgsValidationRule<T> where T : IComparable
    {
        T _value;
        public LessThanOrEqualsRule(T value)
        {
            _value = value;
        }
        public override string GetValidationError()
        {
            return $"The given value must be less than or equals to {_value}";
        }

        public override bool IsValid(T value)
        {
            return value.CompareTo(_value) <= 0;
        }

        public static LessThanOrEqualsRule<T> Value(T value) {
            return new LessThanOrEqualsRule<T>(value);
        }
    }
}

