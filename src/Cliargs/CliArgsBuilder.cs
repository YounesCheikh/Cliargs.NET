using System;
namespace Cliargs
{
	public static class CliArgsBuilder
	{
        public static void Build(ICliArgsContainer container)
        {
            var format = container.Format ?? new CliArgsFormat();
            var argsCollection = Environment.GetCommandLineArgs().Skip(1);
            bool expectValue = false;
            CliArg? cliArg = default;
            foreach (var arg in argsCollection)
            {
                if (expectValue)
                {
                    if (cliArg == null)
                        throw new Exception($"Trying to set a value [{arg}] on a null CliArg.");
                    cliArg.InputValue = arg;
                    expectValue = false;
                    cliArg = null;
                }
                else
                {
                    if (arg.StartsWith(format.NamePrefix))
                    {
                        var argName = arg.Substring(format.NamePrefix.Length);
                        cliArg = container.GetCliArgByName(argName);
                    }
                    else if (arg.StartsWith(format.ShortNamePrefix))
                    {
                        var argShortName = arg.Substring(format.ShortNamePrefix.Length);
                        cliArg = container.GetCliArgByShortName(argShortName);
                    }
                    else
                        throw new Exception($"Unexpected arg or missing prefix: {arg}");

                    if (cliArg == null)
                        throw new Exception($"Unable to find any argument matching the input : {arg}");

                    expectValue = true;
                }
            }

        }
    }
}

