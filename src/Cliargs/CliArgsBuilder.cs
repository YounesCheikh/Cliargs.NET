using System;
namespace Cliargs
{
	static class CliArgsBuilder
	{
        /// <summary>
        /// Build the container
        /// </summary>
        /// <param name="container">The container</param>
        internal static void Build(ICliArgsContainer container)
        {
            var format = container.Format;

            if (IsHelpRequested(container))
                return;

            if (format.AssignationChar == CliArgsFormat.Default.AssignationChar)
                BuildWithDefaultFormat(container);
            else
                BuildWithCustomFormat(container);
        }

        /// <summary>
        /// Build the container with the default format
        /// </summary>
        /// <param name="container">The container</param>
        static void BuildWithDefaultFormat(ICliArgsContainer container)
        {
            var argsCollection = container.ArgumentsProvider.GetCommandLineArgs();
            bool expectValue = false;
            CliArg? cliArg = default;
            foreach (var arg in argsCollection)
            {
                if (expectValue)
                {
                    if (cliArg != null)
                    {
                        cliArg.InputValue = arg;
                        cliArg.IsSet = true;
                        expectValue = false;
                        cliArg = null;
                    }
                    // TODO: Otherwise? 
                }
                else
                {
                    cliArg = ParseArgKey(container, arg);
                    if (cliArg != null)
                    {
                        if (cliArg.Info.RequiresValue)
                            expectValue = true;
                        else
                            cliArg.IsSet = true;
                    }
                    else
                    {
                        throw new CliArgsException($"Unkown argument '{arg}'.");
                    }
                }
            }
        }

        /// <summary>
        /// Build the container with a custom format
        /// </summary>
        /// <param name="container">The format</param>
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
                    if(cliArg == null)
                        throw new CliArgsException($"Unkown argument '{key}'.");
                    cliArg.InputValue = keyValueArray[1];
                }
                else
                {
                    var cliArg = ParseArgKey(container, arg);
                    if(cliArg == null)
                        throw new CliArgsException($"Unkown argument '{arg}'.");

                    cliArg.IsSet = true;
                }
            }
        }

        /// <summary>
        /// Parse the argument key
        /// </summary>
        /// <param name="container">The container</param>
        /// <param name="argInput">The argument key input</param>
        /// <returns>The argument with parsed key</returns>
        internal static CliArg? ParseArgKey(ICliArgsContainer container, string argInput)
        { 
            CliArg? cliArg = null;
            var format = container.Format;
            if (argInput.StartsWith(format.LongNamePrefix))
            {
                var argName = argInput.Substring(format.LongNamePrefix.Length);
                cliArg = container.GetCliArgByLongName(argName);
                
                // Give a second chance in case a long name is not set.
                if(cliArg == null)
                    cliArg = container.GetCliArgByName(argName);
            }
            else if (argInput.StartsWith(format.ShortNamePrefix))
            {
                var argShortName = argInput.Substring(format.ShortNamePrefix.Length);
                cliArg = container.GetCliArgByShortName(argShortName);
            }

            return cliArg;
        }

        /// <summary>
        /// Check whether the help is requested by user 
        /// </summary>
        /// <param name="container">The container</param>
        /// <returns>True if the user requested to display the help, otherwise false.</returns>
        static bool IsHelpRequested(ICliArgsContainer container)
        {
            var format = container.Format;

            var argsCollection = container.ArgumentsProvider.GetCommandLineArgs();

            // Here we expect the help key is input as first argument.
            // If the help tag is after other keys, return false.
            var firstArg = argsCollection.FirstOrDefault();
            if (firstArg != null)
            {
                CliArg? cliArg = null;
                if (firstArg == $"{format.LongNamePrefix}{CliArgsOptions.HelpArg.LongName}")
                {
                    var argName = firstArg.Substring(format.LongNamePrefix.Length);
                    cliArg = container.GetCliArgByLongName(argName);
                }
                else if (firstArg == $"{format.ShortNamePrefix}{CliArgsOptions.HelpArg.ShortName}")
                {
                    var argShortName = firstArg.Substring(format.ShortNamePrefix.Length);
                    cliArg = container.GetCliArgByShortName(argShortName);
                }
                if (cliArg != null)
                {
                    cliArg.IsSet = true;
                    return true;
                }
            }

            return false;
        }
    }
}

