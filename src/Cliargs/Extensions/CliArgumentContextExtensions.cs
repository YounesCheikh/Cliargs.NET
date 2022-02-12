using System;
using Cliargs.Validation;

namespace Cliargs.Extensions
{
	public static class CliArgumentContextExtensions
    {
        public static CliArgumentContext<T> WithRule<T>(this CliArgumentContext<T> argumentContext, ValidationRule<T> rule)
        {
            argumentContext.ValidationContext.AddRule(rule);
            return argumentContext;
        }
    }
}

