using System;
using Cliargs.Rules;
namespace Cliargs
{
    /// <summary>
    /// The command line interface argument
    /// </summary>
	public abstract class CliArg
	{
        /// <summary>
        /// The argument info (metadata)
        /// </summary>
        public CliArgsInfo Info  { get; }

        /// <summary>
        /// The argument name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The argument input value
        /// </summary>
        public string? InputValue { get; internal set; } = null;

        /// <summary>
        /// The value type converter
        /// <remark>This is set to the default type converter. <see cref="ValueTypeConverter.Default"/></remark>
        /// </summary>
        public ValueTypeConverter ValueTypeConverter { get; }

        /// <summary>
        /// Create new instance with a given info
        /// </summary>
        /// <param name="info">The argument info</param>
        public CliArg(CliArgsInfo info): this(info, ValueTypeConverter.Default)
        {
        }

        /// <summary>
        /// Create a new instance with a given info and custom value type converter
        /// </summary>
        /// <param name="info">The argument info</param>
        /// <param name="valueTypeConverter">The custom value type converter</param>
        public CliArg(CliArgsInfo info, ValueTypeConverter valueTypeConverter)
        {
            Info = info;
            this.ValueTypeConverter = valueTypeConverter;
            this.Name = Info.Name;
        }

        /// <summary>
        /// Validate the argument value, It reads the command line input value and
        /// convert it to the typed object
        /// </summary>
        /// <returns>Validation Results of the failed rules</returns>
        public abstract IList<ICliArgsValidationResult> Validate();

        /// <summary>
        /// Create new Argument instance with the given name
        /// </summary>
        /// <typeparam name="T">The argument type</typeparam>
        /// <param name="name">The argument name</param>
        /// <returns>The created instance</returns>
        public static CliArg<T> New<T>(string name)
        {
            return CliArg<T>.New(name);
        }
    }

    public class CliArg<T> : CliArg
    {
        /// <summary>
        /// The argument info (metadata)
        /// </summary>
        /// <param name="info">The argument info</param>
        public CliArg(CliArgsInfo info) : base(info)
        {
            this.ValidationRules = new List<ICliArgsValidationRule<T>>();
        }

        /// <summary>
        /// The argument validation rules
        /// </summary>
        public List<ICliArgsValidationRule<T>> ValidationRules { get; }

        /// <summary>
        /// The argument value
        /// </summary>
        public T? Value { get; internal set; } = default;

        /// <summary>
        /// Create new instance of the argument
        /// </summary>
        /// <param name="name">The argument name</param>
        /// <returns>The created instnace</returns>
        public static CliArg<T> New(string name)
        {
            return new CliArg<T>(new CliArgsInfo(name));
        }

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

