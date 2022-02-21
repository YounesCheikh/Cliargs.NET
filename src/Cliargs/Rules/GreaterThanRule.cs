using System;

namespace Cliargs.Rules
{
	public class GreaterThanRule<T>: CliArgsValidationRule<T> where T: IComparable

    {
        T _value;
        public GreaterThanRule(T value)
        {
            _value = value;
        }
        public override string GetValidationError()
        {
            return $"The given value must be greater than {_value}";
        }

        public override bool IsValid(T value)
        {
            return value.CompareTo(_value) > 0;
        }

        public static GreaterThanRule<T> Value(T value) {
            return new GreaterThanRule<T>(value);
        }
    }
}

