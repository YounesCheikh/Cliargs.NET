using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cliargs.Tests
{
	[TestClass]
	public class AppCliArgsTests
	{
        class SampleSetup : ICliArgsSetup
        {
            public void Configure(ICliArgsContainer container)
            {
				string[] expectedArgs = new[] { "--test", "3" };
				var mockedCLI = new Mock<IArgumentsProvider>();
				mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);
				container.ArgumentsProvider = mockedCLI.Object;
				container.Register(CliArg.New<int>("test"));
            }
        }

        [TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void GetValidationResultsWithoutInitialize()
        {
			AppCliArgs.GetValidationResults();
        }

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void GetRuleWithoutInitialize()
		{
			AppCliArgs.GetArgValue<int>("any");
		}

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void CheckIfArgIsSetWithoutInitialize()
		{
			AppCliArgs.IsSet("any");
		}

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void CheckIfExistValidationErrorsWithoutInitialize()
		{
			var _ = AppCliArgs.HasValidationErrors;
		}

		[TestMethod]
		public void InitializeAppCliArgsTest()
        {
			AppCliArgs.Initialize<SampleSetup>();
			Assert.IsFalse(AppCliArgs.HasValidationErrors);
			Assert.IsTrue(AppCliArgs.IsSet("test"));
			var testArgValue = AppCliArgs.GetArgValue<int>("test");
			Assert.AreEqual(3, testArgValue);
			Assert.IsFalse(AppCliArgs.GetValidationResults().Any());

		}
	}
}

