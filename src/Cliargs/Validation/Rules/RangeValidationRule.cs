using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliargs.Validation
{
    public class RangeValidationRule<T> : ValidationRule<T>
    {
        public T[] Range { get; private set; }
        public RangeValidationRule(T[] range)
        {
            Range = range;
        }

        public override bool IsValid(T value)
        {
            return Range.Any(e=> e!=null && e.Equals(value));
        }

        public override string GetValidationError()
        {
            return string.Format("value must be in range [{0}]", string.Join(",", Range));
        }
    }
}