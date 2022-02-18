using System;
namespace Cliargs
{
    public class EqualsRule<T> : CliArgsValidationRule<T> where T : IComparable

    {
        T _value;
        public EqualsRule(T value)
        {
            _value = value;
        }
        public override string GetValidationError()
        {
            return $"The given value must be less than {_value}";
        }

        public override bool IsValid(T value)
        {
            return value.CompareTo(_value) == 0;
        }
    }
}

