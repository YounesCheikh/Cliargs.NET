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

        public void Register(CliArg arg)
        {
            AddCliArg(arg);
        }

        private void AddCliArg(CliArg arg)
        {
            this._cliArgs.Add(arg.Name, arg);
        }
    }
}

