using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliargs.Validation
{
    public abstract class ArgumentValidation
    {
        /// <summary>
        /// Checks the validation of an argument value
        /// </summary>
        /// <param name="value">The argument value</param>
        /// <returns>If the value if valid for the argument, otherwise false.</returns>
        /// <summary>
        public abstract bool IsValid(object value);
        
    }
}