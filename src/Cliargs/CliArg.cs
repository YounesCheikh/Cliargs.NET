using System;
using Cliargs.Conversion;

namespace Cliargs
{
	public abstract class CliArg
	{
        public CliArgsInfo Info  { get; }

        public ValueTypeConverter ValueTypeConverter { get; }

        public CliArg(CliArgsInfo info): this(info, ValueTypeConverter.Default)
        {
        }

        public CliArg(CliArgsInfo info, ValueTypeConverter valueTypeConverter)
        {
            Info = info;
            this.ValueTypeConverter = valueTypeConverter;
        }
    }

    public class CliArg<T> : CliArg
    {
        public CliArg(CliArgsInfo info) : base(info)
        {
        }

        public string? InputValue { get; set; }

        public T? Value { get; set; }
    }
}

