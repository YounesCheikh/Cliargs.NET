using System;

namespace Cliargs
{
	class CliArgsContainer: ICliArgsContainer
	{
        private readonly Dictionary<string, CliArg> _cliArgs = new Dictionary<string, CliArg>();

        public IReadOnlyDictionary<string, CliArg> CliArgs => _cliArgs;

        internal CliArgsContainer() : this(CliArgsFormat.Default)
        {
            ArgumentsProvider = new ArgumentsProvider();
        }

        internal CliArgsContainer(CliArgsFormat format)
		{
            if (format == null)
                throw new ArgumentNullException(nameof(format));

            this.Format = format;
            ArgumentsProvider = new ArgumentsProvider();
		}

        public CliArgsFormat Format { get; private set; }
        public IArgumentsProvider ArgumentsProvider { get; set; }

        public T? GetValue<T>(string argName)
        {
            if (!CliArgs.ContainsKey(argName))
                throw new CLIArgumentNotFoundException(argName);

            CliArg<T>? arg = CliArgs[argName] as CliArg<T>;

            if (arg != null)
                return arg.Value;

            throw new CliArgsException($"Invalid argument type for argument ({argName}, expected ({CliArgs[argName].GetType()}), but casting to {typeof(T)}");
        }

        /// <summary>
        /// Register a new argument to the container
        /// </summary>
        /// <param name="arg">The argument</param>
        /// <exception cref="CliArgsExecption">
        /// If another argument already registered with the same name, or long name or short name.
        /// </exception>
        public void Register(CliArg arg)
        {
            AddCliArg(arg);
        }

        /// <summary>
        /// Add a new argument
        /// </summary>
        /// <param name="arg">The argument to add</param>
        private void AddCliArg(CliArg arg)
        {
            if(this._cliArgs.Any(e=> e.Value.Info.Name == arg.Info.Name))
                throw new CliArgsException($"Another argument has the same name '{arg.Info.Name}'");

            if(!string.IsNullOrWhiteSpace(arg.Info.ShortName) 
            && this._cliArgs.Any(e=> e.Value.Info.ShortName == arg.Info.ShortName))
                throw new CliArgsException($"Another argument has the same short name '{arg.Info.ShortName}'");

            if(!string.IsNullOrWhiteSpace(arg.Info.LongName) 
            && this._cliArgs.Any(e=> e.Value.Info.LongName == arg.Info.LongName))
                throw new CliArgsException($"Another argument has the same long name '{arg.Info.LongName}'");
            
            this._cliArgs.Add(arg.Name, arg);
        }
    }
}

