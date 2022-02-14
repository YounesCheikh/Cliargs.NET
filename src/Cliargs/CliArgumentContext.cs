using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cliargs.Conversion;
using Cliargs.Validation;

namespace Cliargs
{
    public abstract class CliArgumentContext
    {
        public abstract string Name { get; }

        public string InputValue { get; internal set; } = string.Empty;

        public void SetInputValue(string inputValue)
        {
            InputValue = inputValue;
        }

        public abstract IEnumerable<ArgValidationResult> Validate();
    }

    public class CliArgumentContext<T>: CliArgumentContext
    {

        public CliArgumentContext(ArgumentInfo info, ArgValidationContext<T> validationContext)
        {
            ArgumentNullException.ThrowIfNull(info);
            ArgumentNullException.ThrowIfNull(validationContext);

            this.ArgumentInfo = info;
            this.ValidationContext = validationContext;
        }
        
        public ArgumentInfo ArgumentInfo { get; private set; }

        public ArgValidationContext<T> ValidationContext { get; private set; }

        public override string Name => ArgumentInfo.Name;



        public T? Value { get; internal set; }

        public static CliArgumentContext<T> New(ArgumentInfo info)
        {
            return new CliArgumentContext<T>(info, ArgValidationContext<T>.New(info));
        }

        public override IEnumerable<ArgValidationResult> Validate()
        {
            if (string.IsNullOrWhiteSpace(this.InputValue))
                throw new Exception($"The InputValue is not set, check if the arguments are build successfully before calling Validate method.");

            ValueTypeConverter converter = new ValueTypeConverter();
            this.Value = converter.ConvertFromString<T>(this.InputValue);

            return this.ValidationContext.Validate(Value, this.InputValue);
        }
    }
}