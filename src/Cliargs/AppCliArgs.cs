using System;
using System.Text;

namespace Cliargs
{
	/// <summary>
    /// The main singleton class for Command Line Interface arguments 
    /// </summary>
	public class AppCliArgs
	{
		static AppCliArgs? _instance;

		ICliArgsContainer _cliArgsContainer;

		ICliArgsHelpBuilder _helpBuilder;

		IList<ICliArgsValidationResult> _validationResults;

		readonly static ICliArgsSetup _defaultSetup = new DefaultContainerSetup();
        private string _helpString = String.Empty;

		private AppCliArgs(ICliArgsContainer cliArgsContainer)
		{
			_cliArgsContainer = cliArgsContainer;
			_validationResults = new List<ICliArgsValidationResult>();
			_helpBuilder = new CliArgsHelpBuilder(_cliArgsContainer);
			
		}

		/// <summary>
        /// Get all the validation results for the registered arguments
        /// </summary>
        /// <returns>The list of the validation results</returns>
        /// <exception cref="CliArgsException">If the Instance is not initialized</exception>
		public static IEnumerable<ICliArgsValidationResult> GetValidationResults()
		{
			if (_instance == null)
				throw new CliArgsException($"Instance not initialized, use {nameof(AppCliArgs.Initialize)}");
			return _instance._validationResults;
		}

		/// <summary>
		/// Get a value of a registered argument 
		/// </summary>
		/// <typeparam name="T">The argument type</typeparam>
		/// <param name="argName">The argument name</param>
		/// <returns></returns>
		/// <exception cref="CliArgsException">If the instance is not initialized</exception>
		/// <exception cref="CliArgsException">If the argument doesn't exist</exception>
		/// /// <exception cref="CliArgsException">If the given type doesn't match the registered argument type</exception>
		public static T? GetArgValue<T>(string argName)
		{
			if (_instance == null)
				throw new CliArgsException($"Instance not initialized, use {nameof(AppCliArgs.Initialize)}");
            return _instance._cliArgsContainer.GetValue<T>(argName);
		}

		/// <summary>
		/// Check if an argument is set 
		/// </summary>
		/// <param name="argName">The argument name</param>
		/// <returns>True if the user entered the argument and its value, otherwise false</returns>
		/// <exception cref="CliArgsException">If the instance is not initialized</exception>
		public static bool IsSet(string argName)
		{
			if (_instance == null)
				throw new CliArgsException($"Instance not initialized, use {nameof(AppCliArgs.Initialize)}");
			if(_instance._cliArgsContainer.CliArgs.TryGetValue(argName, out CliArg? arg))
            {
				return arg.IsSet;
            }
			return false;
		}

		/// <summary>
        /// Check if the validation failed and returns true if any argument validation failed
        /// </summary>
		public static bool HasValidationErrors
		{
			get
			{
				if (_instance == null)
					throw new CliArgsException($"Instance not initialized, use {nameof(AppCliArgs.Initialize)}");
				return _instance._validationResults.Any();
			}
		}

        public string HelpString { get => _helpString; set => _helpString = value; }

        /// <summary>
        /// Initialize the instance with a given setup type
        /// </summary>
        /// <typeparam name="TSetup">The Setup type that contains the configuration of all the arguments</typeparam>
        /// <exception cref="CliArgsException">If the instance is not initialized</exception>
        /// <exception cref="CliArgsException">If reading the command line arguments fails</exception>
        /// <exception cref="CliArgsException">If the validation of an argument fails (Conversion, casting, or no expected values in case of validation rules...)</exception>
        public static void Initialize<TSetup>() where TSetup : ICliArgsSetup, new()
		{
			Initialize<TSetup>(CliArgsFormat.Default);
		}

		/// <summary>
		/// Initialize the instance with a given setup type
		/// </summary>
		/// <typeparam name="TSetup">The Setup type that contains the configuration of all the arguments</typeparam>
		/// <param name="format">The custom format</param>
		/// <exception cref="CliArgsException">If the instance is not initialized</exception>
		/// <exception cref="CliArgsException">If reading the command line arguments fails</exception>
		/// <exception cref="CliArgsException">If the validation of an argument fails (Conversion, casting, or no expected values in case of validation rules...)</exception>
		public static void Initialize<TSetup>(CliArgsFormat format) where TSetup : ICliArgsSetup, new() 
        {
			var container = new CliArgsContainer(format);
			_defaultSetup.Configure(container);
			TSetup setup = new TSetup();
			setup.Configure(container);
			CliArgsBuilder.Build(container);
			var instnace = new AppCliArgs(container);
			instnace.HelpString = instnace._helpBuilder.Build();
			var validationResult = CliArgsValidator.Validate(container);
			instnace._validationResults = validationResult;
			_instance = instnace;
        }

		/// <summary>
		/// Check whether the help is requested or not
		/// </summary>
		/// <returns>True if the help is requested otherwise false</returns>
		public static bool IsHelpRequested() {
			return IsSet(CliArgsOptions.HelpArg.Name);
		}

		/// <summary>
		/// The default help string 
		/// </summary>
		/// <returns>The help string with 2 columns</returns>
		public static string GetHelpString() {

			if (_instance == null)
				throw new CliArgsException($"Instance not initialized, use {nameof(AppCliArgs.Initialize)}");
			return _instance.HelpString;
		}
	}
}

