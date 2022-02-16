using System;

namespace Cliargs
{
	public class CliArgsRepository: ICliArgsRepository
	{
		private readonly Dictionary<string, CliArg> _cliArgs = new Dictionary<string, CliArg>();

		private readonly Dictionary<string, CliArgsInfo> _cliArgsInfos = new Dictionary<string, CliArgsInfo>();
		private readonly Dictionary<string, ICliArgsValidationContext> _cliArgsValidationContexts = new Dictionary<string, ICliArgsValidationContext>();

		public CliArgsRepository()
		{
		}

		public IReadOnlyDictionary<string, CliArgsInfo> CliArgsInfos => _cliArgsInfos;

		public IReadOnlyDictionary<string, ICliArgsValidationContext> CliArgsValidationContexts => _cliArgsValidationContexts;

		public IReadOnlyDictionary<string, CliArg> CliArgs => _cliArgs;

        public void AddCliArgsInfo(CliArgsInfo info)
        {
			_cliArgsInfos.Add(info.Name, info);
        }

        public void AddCliArgsValidationContext(string name, ICliArgsValidationContext validationContext)
        {
			_cliArgsValidationContexts.Add(name, validationContext);
        }
    }
}

