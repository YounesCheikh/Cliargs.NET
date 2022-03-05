using System;
using Cliargs.Rules;
namespace Cliargs
{
    /// <summary>
    /// The command line interface argument
    /// </summary>
	public class CliArg
	{
        public CliArg(string name): this(new CliArgsInfo(name) { RequiresValue = false })
        {
        }

        /// <summary>
        /// The argument info (metadata)
        /// </summary>
        public CliArgsInfo Info  { get; }

        /// <summary>
        /// The argument name
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// The argument input value
        /// </summary>
        public string? InputValue { get; internal set; } = null;

        /// <summary>
        /// Check if the argument is set by the user
        /// </summary>
        public bool IsSet { get; internal set; } = false;

        /// <summary>
        /// Create new instance with a given info
        /// </summary>
        /// <param name="info">The argument info</param>
        public CliArg(CliArgsInfo info)
        {
            this.Info = info;
            this.Name = info.Name;
        }

        /// <summary>
        /// Validate the argument value, It reads the command line input value and
        /// convert it to the typed object
        /// </summary>
        /// <returns>Validation Results of the failed rules</returns>
        public virtual IList<ICliArgsValidationResult> Validate()
        {
            return new List<ICliArgsValidationResult>();
        }

        public virtual object? GetValue() {
            return default;
        }

        /// <summary>
        /// Create new Argument instance with the given name
        /// </summary>
        /// <typeparam name="T">The argument type</typeparam>
        /// <param name="name">The argument name</param>
        /// <returns>The created instance</returns>
        public static CliArg<T> New<T>(string name)
        {
            return new CliArg<T>(new CliArgsInfo(name));
        }

        public static CliArg New(string name)
        {
            return new CliArg(name);
        }
    }

    public class CliArg<T> : CliArg
    {
        /// <summary>
        /// The argument info (metadata)
        /// </summary>
        /// <param name="info">The argument info</param>
        public CliArg(CliArgsInfo info) : this(info, ValueTypeConverter.Default)
        {
            this.ValidationRules = new List<ICliArgsValidationRule<T>>();
        }

        /// <summary>
        /// Create a new instance with a given info and custom value type converter
        /// </summary>
        /// <param name="info">The argument info</param>
        /// <param name="valueTypeConverter">The custom value type converter</param>
        public CliArg(CliArgsInfo info, ValueTypeConverter valueTypeConverter): base(info)
        {
            this.Converter = valueTypeConverter;
            ValidationRules = new List<ICliArgsValidationRule<T>>();
        }

        public override string Name => base.Name;
        /// <summary>
        /// The value type converter
        /// <remark>This is set to the default type converter. <see cref="ValueTypeConverter.Default"/></remark>
        /// </summary>
        public IValueTypeConverter Converter { get; internal set; }

        /// <summary>
        /// The argument validation rules
        /// </summary>
        public List<ICliArgsValidationRule<T>> ValidationRules { get; }

        /// <summary>
        /// The argument value
        /// </summary>
        public T? Value { get; internal set; } = default;

        /// <summary>
        /// Execute the validation rules on the argument value
        /// </summary>
        /// <returns>The results of execution of validation rules if any fails</returns>
        /// <exception cref="CliArgsException">If failed to parse the input value into the given type 'T'</exception>
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

            var value = this.Converter.GetConverted(typeof(T),InputValue);
            if (value == null)
                throw new CliArgsException($"Unable to cast value '{InputValue}' to type {typeof(T)}");

            this.Value = (T)value;

            foreach (var rule in ValidationRules)
            {
                if (!rule.IsValid(this.Value))
                {
                    results.Add(new CliArgsValidationResult(rule, Info, false));
                }
            }

            return results;
        }

        public override object? GetValue()
        {
            return this.Value;
        }
    }
}

