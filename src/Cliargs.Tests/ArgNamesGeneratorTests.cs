using System;
using Cliargs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class ArgNamesGeneratorTests
	{
		[TestMethod]
		public void SlugifyNameTest()
		{
			IArgNamesGenerator generator = new ArgNamesGenerator();
			var results = generator.GenerateLongName("---   Hello World     This Is Just A -----Test  ----");
			Assert.AreEqual("hello-world-this-is-just-a-test", results);

			results = generator.GenerateLongName("Hello World");
			Assert.AreEqual("hello-world", results);

			results = generator.GenerateLongName("Command");
			Assert.AreEqual("command", results);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void FailsSlugifyNameTest() {
			IArgNamesGenerator generator = new ArgNamesGenerator();
			var results = generator.GenerateLongName("     ");
		}

		[TestMethod]
		public void ShortifyNameTest() 
		{
			IArgNamesGenerator generator = new ArgNamesGenerator();
			var results = generator.GenerateShortName("hello-world-this-is-just-a-test");
			Assert.AreEqual("hw", results);

			results = generator.GenerateShortName("command");
			Assert.AreEqual("c", results);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void FailsShortifyNameTest() {
			IArgNamesGenerator generator = new ArgNamesGenerator();
			var results = generator.GenerateShortName("     ");
		}
	}
}

