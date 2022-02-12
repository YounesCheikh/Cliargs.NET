using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliargs.Validation
{
    public class TypeValidationRule<T> : ValidationRule<T>
    {
        /// <summary>
        /// Creates a new instance of the argument type validation instance
        /// </summary>
        /// <param name="expectedType">The expected type</param>
        public TypeValidationRule()
        {
        }

        /// <summary>
        /// Checks if the type of the value equals to the defined expected type
        /// </summary>
        /// <param name="value">The argument value</param>
        /// <returns>Returns true if the value's type equals to expected type</returns>
        public override bool IsValid(T value)
        {
            return value != null && value.GetType() == typeof(T);
        }
    }
}