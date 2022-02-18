using System;
namespace Cliargs
{
	public class AppCliArgs
	{
		private AppCliArgs()
        {
			_cliArgsContainer = new CliArgsContainer(CliArgsFormat.Default);
			_validationResults = new List<ICliArgsValidationResult>();
		}
		private static AppCliArgs? _instance;

		ICliArgsContainer _cliArgsContainer;

		IList<ICliArgsValidationResult> _validationResults;

		private AppCliArgs(ICliArgsContainer cliArgsContainer)
		{
			_cliArgsContainer = cliArgsContainer;
			_validationResults = new List<ICliArgsValidationResult>();
		}

		public static IEnumerable<ICliArgsValidationResult> GetValidationResults()
		{
			if (_instance == null)
				throw new Exception($"Instance not initialized, use {nameof(AppCliArgs.Initialize)}");
			return _instance._validationResults;
		}

		public static T? GetArgValue<T>(string argName)
		{
			if (_instance == null)
				throw new Exception($"Instance not initialized, use {nameof(AppCliArgs.Initialize)}");
			return _instance._cliArgsContainer.GetValue<T>(argName);
		}

		public static bool IsSet(string argName)
		{
			if (_instance == null)
				throw new Exception($"Instance not initialized, use {nameof(AppCliArgs.Initialize)}");
			return _instance._cliArgsContainer.CliArgs.ContainsKey(argName);
		}

		public static bool HasValidationErrors
		{
			get
			{
				if (_instance == null)
					throw new Exception($"Instance not initialized, use {nameof(AppCliArgs.Initialize)}");
				return _instance._validationResults.Any();
			}
		}
        

		public static void Initialize<TSetup>() where TSetup : ICliArgsSetup, new()
		{
			Initialize<TSetup>(CliArgsFormat.Default);
		}

		public static void Initialize<TSetup>(CliArgsFormat format) where TSetup : ICliArgsSetup, new() 
        {
			var container = new CliArgsContainer(format);
			TSetup setup = new TSetup();
			setup.Configure(container);
			CliArgsBuilder.Build(container);
			var instnace = new AppCliArgs(container);
			var validationResult = CliArgsValidator.Validate(container);
			instnace._validationResults = validationResult;
			_instance = instnace;
        }
	}
}

