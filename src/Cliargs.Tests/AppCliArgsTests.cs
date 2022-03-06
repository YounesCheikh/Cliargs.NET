using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cliargs.Tests
{
	[TestClass]
	public class AppCliArgsTests
	{
		[TestCleanup]
		public void CleanUp()
        {
			var filed = typeof(AppCliArgs).GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
			if (filed == null)
				throw new Exception("Unable to get the singleton instance field");
			filed.SetValue(null, null);
		}

		class SampleArgsObj
        {
			[CliArgName]
			public int Test { get; set; }
        }

		class SingleArgSetup : ICliArgsSetup
		{
			public void Configure(ICliArgsContainer container)
			{
				string[] expectedArgs = new[] { "--test", "3" };
				var mockedCLI = new Mock<IArgumentsProvider>();
				mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);
				container.ArgumentsProvider = mockedCLI.Object;
				ICliArgsSetup defaultSetup = new DefaultContainerSetup();
				container.Register(CliArg.New<int>(nameof(SampleArgsObj.Test)).WithLongName("test"));
			}
		}

		class SampleSetup : ICliArgsSetup
        {
            public void Configure(ICliArgsContainer container)
            {
				string[] expectedArgs = new[] { "--test", "3", "--too-long-command-line-interface-argument" };
				var mockedCLI = new Mock<IArgumentsProvider>();
				mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);
				container.ArgumentsProvider = mockedCLI.Object;
				ICliArgsSetup defaultSetup = new DefaultContainerSetup();
				container.Register(CliArg.New<int>("test"));
				container.Register(CliArg.New("longArg").WithLongName("too-long-command-line-interface-argument"));
            }
        }

		class HelpRequestedSampleSetup : ICliArgsSetup
        {
            public void Configure(ICliArgsContainer container)
            {
				string[] expectedArgs = new[] { "--help"};
				var mockedCLI = new Mock<IArgumentsProvider>();
				mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);
				container.ArgumentsProvider = mockedCLI.Object;
				ICliArgsSetup defaultSetup = new DefaultContainerSetup();
            }
        }

		class OtherSetup : ICliArgsSetup
		{
			public void Configure(ICliArgsContainer container)
			{
				string[] expectedArgs = new[] { "--kk", "3" };
				var mockedCLI = new Mock<IArgumentsProvider>();
				mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);
				container.ArgumentsProvider = mockedCLI.Object;
				container.Register(CliArg.New<int>("kk").WithShortName("k"));
			}
		}

		[TestMethod]
		public void ParseArgumentsToObj()
		{ 
			AppCliArgs.Initialize<SingleArgSetup>();
			SampleArgsObj obj = AppCliArgs.GetArgsParsed<SampleArgsObj>();
			Assert.IsNotNull(obj);
			Assert.AreEqual(3, obj.Test);
		}

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void ParseArgumentsToObjWithouInitialize()
		{
			_ = AppCliArgs.GetArgsParsed<SampleArgsObj>();
		}

		[TestMethod]
		public void ShortArgumentsBuild()
        {
			AppCliArgs.Initialize<OtherSetup>();
			_ = AppCliArgs.GetHelpString();
        }

		[TestMethod]
		public void LongArgumentsBuild()
		{
			AppCliArgs.Initialize<SampleSetup>();
			_ = AppCliArgs.GetHelpString();
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

		[TestMethod]
		public void CheckIfArgIsSet()
		{
			AppCliArgs.Initialize<SampleSetup>();
			Assert.IsFalse(AppCliArgs.HasValidationErrors);
			Assert.IsTrue(AppCliArgs.IsSet("test"));
			Assert.IsFalse(AppCliArgs.IsSet(CliArgsOptions.HelpArg.Name));
			Assert.IsFalse(AppCliArgs.IsSet("fake"));
			var testArgValue = AppCliArgs.GetArgValue<int>("test");
			Assert.AreEqual(3, testArgValue);
			Assert.IsFalse(AppCliArgs.GetValidationResults().Any());
		}

		[TestMethod]
		public void CheckIfHelpIsRequested()
		{ 
			AppCliArgs.Initialize<HelpRequestedSampleSetup>();
			Assert.IsTrue(AppCliArgs.IsHelpRequested());
		}

		[TestMethod]
		public void CheckIfHelpIsNotRequested()
		{ 
			AppCliArgs.Initialize<SampleSetup>();
			Assert.IsFalse(AppCliArgs.IsHelpRequested());
		}

		[TestMethod]
		public void CheckIfLongArgIsSet()
		{
			AppCliArgs.Initialize<SampleSetup>();
			Assert.IsFalse(AppCliArgs.HasValidationErrors);
			Assert.IsTrue(AppCliArgs.IsSet("longArg"));
		}

		[TestMethod]
		public void GetHelpStringAfterInitialize()
		{
			AppCliArgs.Initialize<SampleSetup>();
			Assert.IsFalse(string.IsNullOrEmpty(AppCliArgs.GetHelpString()));
		}

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void GetHelpStringWithoutInitialize()
		{
			AppCliArgs.GetHelpString();
		}
	}

}

