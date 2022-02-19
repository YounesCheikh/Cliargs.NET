using System;
namespace Cliargs
{
	static class CliArgsBuilder
	{
        internal static void Build(ICliArgsContainer container)
        {
            var format = container.Format;
            if (format.AssignationChar == ' ')
                BuildWithDefaultFormat(container);
            else
                BuildWithCustomFormat(container);
        }

        static void BuildWithDefaultFormat(ICliArgsContainer container)
        {
            var argsCollection = container.ArgumentsProvider.GetCommandLineArgs();
            bool expectValue = false;
            CliArg? cliArg = default;
            foreach (var arg in argsCollection)
            {
                if (expectValue)
                {
                    if (cliArg == null)
                        throw new CliArgsException($"Trying to set a value [{arg}] on a null CliArg.");
                    cliArg.InputValue = arg;
                    expectValue = false;
                    cliArg = null;
                }
                else
                {
                    cliArg = ParseArgKey(container, arg);
                    expectValue = true;
                }
            }
        }

        static void BuildWithCustomFormat(ICliArgsContainer container)
        {
            var format = container.Format;
            var argsCollection = container.ArgumentsProvider.GetCommandLineArgs();

            foreach (var arg in argsCollection)
            {
                if(arg.Contains(format.AssignationChar))
                {
                    var keyValueArray = arg.Split(format.AssignationChar);
                    if(keyValueArray.Length > 2)
                        throw new CliArgsException($"Argument with more than one assignation character '{arg}'.");

                    var key = keyValueArray[0];
                    var cliArg = ParseArgKey(container, key);
                    cliArg.InputValue = keyValueArray[1];
                }
                else
                {
                    throw new CliArgsException($"Argument without assignation character '{arg}'.");
                }
            }
        }

        internal static CliArg ParseArgKey(ICliArgsContainer container, string argInput)
        { 
            CliArg cliArg;
            var format = container.Format;
            if (argInput.StartsWith(format.NamePrefix))
            {
                var argName = argInput.Substring(format.NamePrefix.Length);
                cliArg = container.GetCliArgByName(argName);
            }
            else if (argInput.StartsWith(format.ShortNamePrefix))
            {
                var argShortName = argInput.Substring(format.ShortNamePrefix.Length);
                cliArg = container.GetCliArgByShortName(argShortName);
            }
            else
                throw new CliArgsException($"Unexpected arg or missing prefix: {argInput}");

            if (cliArg == null)
                throw new CliArgsException($"Unable to find any argument matching the input : {argInput}");

            return cliArg;
        }
    }
}

