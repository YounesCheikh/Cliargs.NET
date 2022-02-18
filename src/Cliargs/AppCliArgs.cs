using System;
namespace Cliargs
{
	public class AppCliArgs
	{
		ICliArgsContainer _cliArgsContainer;

		IList<ICliArgsValidationResult> _validationResults; 

		private AppCliArgs(ICliArgsContainer cliArgsContainer)
		{
			_cliArgsContainer = cliArgsContainer;
			_validationResults = new List<ICliArgsValidationResult>();
		}

		public IEnumerable<ICliArgsValidationResult> GetValidationResults()
		{
			return _validationResults;
		}

		public T? GetArgValue<T>(string argName)
        {
			return _cliArgsContainer.GetValue<T>(argName);
        }

		public bool IsSet(string argName)
        {
			return _cliArgsContainer.CliArgs.ContainsKey(argName);
        }

		public bool HasValidationErrors => _validationResults.Any();
        

		public static AppCliArgs Use<TSetup>() where TSetup : ICliArgsSetup, new()
		{
			return Use<TSetup>(CliArgsFormat.Default);
		}

		public static AppCliArgs Use<TSetup>(CliArgsFormat format) where TSetup : ICliArgsSetup, new() 
        {
			var container = new CliArgsContainer(format);
			TSetup setup = new TSetup();
			setup.Configure(container);
			CliArgsBuilder.Build(container);
			var instnace = new AppCliArgs(container);
			var validationResult = CliArgsValidator.Validate(container);
			instnace._validationResults = validationResult;
			return instnace;
        }
	}
}

