using System;
namespace Cliargs
{
	internal class ArgumentsProvider : IArgumentsProvider
    {
		public ArgumentsProvider()
		{
		}

        public string[] GetCommandLineArgs()
        {
            return Environment.GetCommandLineArgs().Skip(1).ToArray();
        }
    }
}

