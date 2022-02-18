using System;
using Cliargs.Conversion;

namespace Cliargs
{
	public abstract class CliArg
	{
        public CliArgsInfo Info  { get; }

        public string Name { get; }

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
    }

    public class CliArg<T> : CliArg
    {
        public CliArg(CliArgsInfo info) : base(info)
        {
            this.ValidationRules = new List<ICliArgsValidationRule<T>>();
        }

        public List<ICliArgsValidationRule<T>> ValidationRules { get; }

        public string? InputValue { get; set; } = null;

        public T? Value { get; set; } = default;

        public static CliArg<T> New(string name)
        {
            return new CliArg<T>(new CliArgsInfo(name));
        }
    }
}

