using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cliargs.Validation;

namespace Cliargs
{
    public class CliArgumentContext
    {

    }

    public class CliArgumentContext<T>: CliArgumentContext
    {

        public CliArgumentContext(ArgumentInfo info, ArgValidationContext<T> validationContext)
        {
            this.ArgumentInfo = info;
            this.ValidationContext = validationContext;
        }
        
        public ArgumentInfo ArgumentInfo { get; private set; }

        public ArgValidationContext<T> ValidationContext { get; private set; }

        public static CliArgumentContext<T> New(ArgumentInfo info)
        {
            return new CliArgumentContext<T>(info, new ArgValidationContext<T>());
        }
    }
}