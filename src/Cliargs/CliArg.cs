using System;

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

        public abstract IEnumerable<ICliArgsValidationResult> Validate();
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

        public override IEnumerable<ICliArgsValidationResult> Validate()
        {
            if (InputValue == null)
            {
                if (!this.Info.Optional)
                {
                    yield return new CliArgsValidationResult(new NonNullArgumentRule(), Info, false);
                }

                yield break;
            }
            
            foreach(var rule in ValidationRules)
            {
                var value = this.ValueTypeConverter.ConvertFromString<T>(InputValue);
                if(!rule.IsValid(value))
                {
                    yield return new CliArgsValidationResult(rule, Info, false);
                }
                else
                {
                    this.Value = value;
                }
            }
        }
    }
}

