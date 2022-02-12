using System;
using Cliargs.Validation;

namespace Cliargs.Extensions
{
	public static class ArgValidationContextExtensions
	{
		public static ArgValidationContext<T> WithRule<T>(this ArgValidationContext<T> validationContext, ValidationRule<T> rule)
        {
			validationContext.AddRule(rule);
			return validationContext;
        } 
	}
}

