using System;
namespace Cliargs
{
	public class CLIArguments
	{
		private readonly Dictionary<string, CliArgumentContext> argumentContexts = new Dictionary<string, CliArgumentContext>();

		private CLIArguments()
		{
		}

		public void AddCliArgument<T>(CliArgumentContext<T> argumentContext)
        {
			argumentContexts.Add(argumentContext.ArgumentInfo.Name, argumentContext);
        }

		public static CLIArguments New<TConfiguration>() where TConfiguration : IArgsConfiguration, new()
		{
			IArgsConfiguration configuration = new TConfiguration();
			var args = new CLIArguments();
			configuration.Configure(args);
			return args;
		}

		public IEnumerable<Cliargs.Validation.ArgValidationResult> Validate()
        {
			foreach(var c in argumentContexts)
            {
				var resultCollection = c.Value.Validate();
				foreach (var result in resultCollection)
					yield return result;
            }
		}

		public void Build()
        {
			var appArgs = Environment.GetCommandLineArgs();
			/// --key value -k value
			Dictionary<string, string> elements = new Dictionary<string, string>();
			var currentParseIsKey = true;
			string currentKey = string.Empty;
			var ignoreFirstArg = true;
            foreach(var appArgElement in appArgs)
            {
				if(ignoreFirstArg)
                {
					ignoreFirstArg = false;
					continue;
                }
				if(currentParseIsKey)
                {
					if(appArgElement.StartsWith("-"))
                    {
						currentKey = appArgElement;
						currentParseIsKey = false;
                    }
					else
                    {
						throw new Exception($"Expected to have a key but found {appArgElement} instead");
                    }
                }
				else
                {
					elements.Add(currentKey, appArgElement);
					currentParseIsKey = true;
                }
            }

			foreach(var element in elements)
            {
				string argumentName = string.Empty;
				if(element.Key.StartsWith("--"))
                {
					argumentName = element.Key.Substring(2);
                }
				else
                {
					throw new NotImplementedException("Building using arguments shortnames is not implemented yet.");
                }

				var context = this.argumentContexts.SingleOrDefault(e => e.Key == argumentName).Value;
				if (context == null)
					throw new Exception($"No Argument is set with name = {argumentName}");

				context.SetInputValue(element.Value);
			}
        }

		public T? GetArgValue<T>(string key)
		{
            if (!this.argumentContexts.ContainsKey(key))
				throw new Exception($"Unable to find the context with the given key {key}");
			var item = argumentContexts[key];


			CliArgumentContext<T>? element = item as CliArgumentContext<T>;
			if (element != null)
            {
                return element.Value;
            }

            throw new Exception($"Unable to cast the context value into a context with the given type {typeof(T)}");

		}
	}
}

