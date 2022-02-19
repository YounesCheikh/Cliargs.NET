using System;
using Cliargs.Rules;
namespace Cliargs
{
	public abstract class CliArg
	{
        public CliArgsInfo Info  { get; }

        public string Name { get; }

        public string? InputValue { get; set; } = null;

        public ValueTypeConverter ValueTypeConverter { get; }

        public CliArg(CliArgsInfo info): this(info, ValueTypeConverter.Default)
        {
        }

        public CliArg(CliArgsInfo info, ValueTypeConverter valueTypeConverter)
        {
            Info = info;
            this.ValueTypeConverter = valueTypeConverter;
            this.Name = Info.Name;
        }

        public abstract IList<ICliArgsValidationResult> Validate();

        public static CliArg<T> New<T>(string name)
        {
            return CliArg<T>.New(name);
        }
    }

    public class CliArg<T> : CliArg
    {
        public CliArg(CliArgsInfo info) : base(info)
        {
            this.ValidationRules = new List<ICliArgsValidationRule<T>>();
        }

        public List<ICliArgsValidationRule<T>> ValidationRules { get; }

        public T? Value { get; set; } = default;

        public static CliArg<T> New(string name)
        {
            return new CliArg<T>(new CliArgsInfo(name));
        }

        public override IList<ICliArgsValidationResult> Validate()
        {
            var results = new List<ICliArgsValidationResult>();
            if (InputValue == null)
            {
                
                if (!this.Info.Optional)
                {
                    results.Add(new CliArgsValidationResult(new NonNullArgumentRule(), Info, false));
                }
                return results;
            }

            var value = this.ValueTypeConverter.ConvertFromString<T>(InputValue);
            if (value == null)
                throw new CliArgsException($"Unable to cast value '{InputValue}' to type {typeof(T)}");

            this.Value = value;

            foreach (var rule in ValidationRules)
            {
                if (!rule.IsValid(value))
                {
                    results.Add(new CliArgsValidationResult(rule, Info, false));
                }
            }

            return results;
        }
    }
}

