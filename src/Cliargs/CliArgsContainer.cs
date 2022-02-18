using System;

namespace Cliargs
{
	class CliArgsContainer: ICliArgsContainer
	{
        private readonly Dictionary<string, CliArg> _cliArgs = new Dictionary<string, CliArg>();

        public IReadOnlyDictionary<string, CliArg> CliArgs => _cliArgs;

        

        internal CliArgsContainer() : this(new CliArgsFormat())
        {
        }

        internal CliArgsContainer(CliArgsFormat format)
		{
            this.Format = format;
		}

        public CliArgsFormat Format { get; }

        public T? GetValue<T>(string argName)
        {
            if (!CliArgs.ContainsKey(argName))
                return default;

            CliArg<T>? arg = CliArgs[argName] as CliArg<T>;

            if (arg != null)
                return arg.Value;

            return default;
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

