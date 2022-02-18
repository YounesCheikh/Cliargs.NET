using System;

namespace Cliargs
{
	public class CliArgsRepository: ICliArgsRepository
	{
		private readonly Dictionary<string, CliArg> _cliArgs = new Dictionary<string, CliArg>();

		public IReadOnlyDictionary<string, CliArg> CliArgs => _cliArgs;

        public void AddCliArg(CliArg arg)
        {
			this._cliArgs.Add(arg.Name, arg);
        }
    }
}

