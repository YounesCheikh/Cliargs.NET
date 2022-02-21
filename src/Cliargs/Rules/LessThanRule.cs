using System;
namespace Cliargs.Rules
{
    public class LessThanRule<T> : CliArgsValidationRule<T> where T : IComparable

    {
        T _value;
        public LessThanRule(T value)
        {
            _value = value;
        }
        public override string GetValidationError()
        {
            return $"The given value must be less than {_value}";
        }

        public override bool IsValid(T value)
        {
            return value.CompareTo(_value) < 0;
        }

        public static LessThanRule<T> Value(T value) {
            return new LessThanRule<T>(value);
        }
    }
}

