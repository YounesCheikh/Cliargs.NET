using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class ArgumentsProviderTests
	{
		[TestMethod]
		public void GetArgsFromEnvironment()
        {
			IArgumentsProvider argumentsProvider = new ArgumentsProvider();
			var args =  argumentsProvider.GetCommandLineArgs();
			Assert.IsNotNull(args);
			
			var envArgs = Environment.GetCommandLineArgs().Skip(1).ToArray();
			Assert.AreEqual(envArgs.Length, args.Length);

            for (int i = 0; i < envArgs.Length; i++)
            {
				Assert.AreEqual(args[i], envArgs[i]);
				Console.WriteLine(args[i]);
			}
		}
	}
}

