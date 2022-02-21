using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cliargs.Tests
{
    [TestClass]
	public partial class CliArgsBuilderTests
	{
        #region Key Only parsing
        [TestMethod]
		public void ParseKeyTestDefaultFormatSuccess()
		{
			ICliArgsContainer container = new CliArgsContainer();
			container.Register(CliArg.New<int>("test"));
			container.Register(CliArg.New<int>("other").WithShortName("o"));
			var argFromName = CliArgsBuilder.ParseArgKey(container, $"{container.Format.NamePrefix}test");
			var argFromShortName = CliArgsBuilder.ParseArgKey(container, $"{container.Format.ShortNamePrefix}o");
			Assert.IsNotNull(argFromName);
			Assert.IsNotNull(argFromShortName);
		}

		[TestMethod]
		public void ParseKeyTestCustomFormatSuccess()
		{
			ICliArgsContainer container = new CliArgsContainer(new CliArgsFormat('=', ":", "/"));
			container.Register(CliArg.New<int>("test"));
			container.Register(CliArg.New<int>("other").WithShortName("o"));
			var argFromName = CliArgsBuilder.ParseArgKey(container, $"{container.Format.NamePrefix}test");
			var argFromShortName = CliArgsBuilder.ParseArgKey(container, $"{container.Format.ShortNamePrefix}o");
			Assert.IsNotNull(argFromName);
			Assert.IsNotNull(argFromShortName);
		}

		[TestMethod]
		public void ParseKeyTestWithWrongNamePrefix()
		{
			ICliArgsContainer container = new CliArgsContainer();
			container.Register(CliArg.New<int>("test"));
			Assert.IsNull(CliArgsBuilder.ParseArgKey(container, $":test"));
		}

		[TestMethod]
		public void ParseKeyTestWithWrongShortNamePrefix()
		{
			ICliArgsContainer container = new CliArgsContainer();
			container.Register(CliArg.New<int>("test").WithShortName("t"));
			Assert.IsNull(CliArgsBuilder.ParseArgKey(container, $":t"));
		}

		[TestMethod]
		public void ParseKeyTestNoExistKeyFailure()
		{
			ICliArgsContainer container = new CliArgsContainer();
			Assert.IsNull(CliArgsBuilder.ParseArgKey(container, $"{container.Format.NamePrefix}noexistkey"));
		}

		[TestMethod]
		public void ParseKeyTestNoExistShortNameFailure()
		{
			ICliArgsContainer container = new CliArgsContainer();
			Assert.IsNull(CliArgsBuilder.ParseArgKey(container, $"{container.Format.ShortNamePrefix}n"));
		}
		#endregion

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void BuildFromDefaultFormatFailureOnUnkownKeys()
		{
			string[] expectedArgs = new[] { "--te", "3", "--oth", "1" };
			var mockedCLI = new Mock<IArgumentsProvider>();
			mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);

			ICliArgsContainer container = new CliArgsContainer()
			{
				ArgumentsProvider = mockedCLI.Object
			};

			ICliArgsSetup defaultSetup = new DefaultContainerSetup();
			defaultSetup.Configure(container);

			container.Register(CliArg.New<int>("test"));
			container.Register(CliArg.New<int>("other"));
			
			CliArgsBuilder.Build(container);
		}

		[TestMethod]
		public void BuildFromDefaultFormatSuccess()
        {
			string[] expectedArgs = new[] { "--test", "3", "--other", "1" };
			var mockedCLI = new Mock<IArgumentsProvider>();
			mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);

			ICliArgsContainer container = new CliArgsContainer()
			{
				ArgumentsProvider = mockedCLI.Object
			};

			ICliArgsSetup defaultSetup = new DefaultContainerSetup();
			defaultSetup.Configure(container);

			container.Register(CliArg.New<int>("test"));
			container.Register(CliArg.New<int>("other"));

			CliArgsBuilder.Build(container);
			var test = container.GetCliArgByName("test");
			Assert.IsNotNull(test);
			Assert.AreEqual("3", test.InputValue);
			var other = container.GetCliArgByName("other");
			Assert.IsNotNull(other);
			Assert.AreEqual("1", other.InputValue);
		}

		[TestMethod]
		public void BuildFromCustomFormatSuccess()
		{ 
			string[] expectedArgs = new[] { "--test=3", "--other=1" };
			var mockedCLI = new Mock<IArgumentsProvider>();
			mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);

			ICliArgsContainer container = new CliArgsContainer(new CliArgsFormat('='))
			{
				ArgumentsProvider = mockedCLI.Object
			};

			container.Register(CliArg.New<int>("test"));
			container.Register(CliArg.New<int>("other"));

			CliArgsBuilder.Build(container);
			var test = container.GetCliArgByName("test");
			Assert.IsNotNull(test);
			Assert.AreEqual("3", test.InputValue);
			var other = container.GetCliArgByName("other");
			Assert.IsNotNull(other);
			Assert.AreEqual("1", other.InputValue);
		}

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void BuildFromCustomFormatMissingNamePrefeixFailure()
		{
			string[] expectedArgs = new[] { "test=3" };
			var mockedCLI = new Mock<IArgumentsProvider>();
			mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);

			ICliArgsContainer container = new CliArgsContainer(new CliArgsFormat('='))
			{
				ArgumentsProvider = mockedCLI.Object
			};

			container.Register(CliArg.New<int>("test"));

			CliArgsBuilder.Build(container);
		}

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void BuildFromCustomFormatMissingAssignationChar()
		{
			string[] expectedArgs = new[] { "test","3" };
			var mockedCLI = new Mock<IArgumentsProvider>();
			mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);

			ICliArgsContainer container = new CliArgsContainer(new CliArgsFormat('='))
			{
				ArgumentsProvider = mockedCLI.Object
			};

			container.Register(CliArg.New<int>("test"));

			CliArgsBuilder.Build(container);
		}

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void BuildFromCustomFormatMultiAssignationChars()
		{
			string[] expectedArgs = new[] { "test=3=1" };
			var mockedCLI = new Mock<IArgumentsProvider>(); 
			mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);

			ICliArgsContainer container = new CliArgsContainer(new CliArgsFormat('='))
			{
				ArgumentsProvider = mockedCLI.Object
			};

			ICliArgsSetup defaultSetup = new DefaultContainerSetup();
			defaultSetup.Configure(container);

			container.Register(CliArg.New<int>("test"));

			CliArgsBuilder.Build(container);
		}

		[TestMethod]
		public void BuildFromDefaultFormatWithRequestedHelp()
		{
			string[] expectedArgs = new[] { "--help"};
			var mockedCLI = new Mock<IArgumentsProvider>();
			mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);

			ICliArgsContainer container = new CliArgsContainer()
			{
				ArgumentsProvider = mockedCLI.Object
			};

			ICliArgsSetup defaultSetup = new DefaultContainerSetup();
			defaultSetup.Configure(container);
			container.Register(CliArg.New<int>("test"));
			container.Register(CliArg.New<int>("other"));

			CliArgsBuilder.Build(container);

			var singleSetArg = container.GetArgs().ToList().SingleOrDefault(e=> e.IsSet);
			Assert.IsNotNull(singleSetArg);
			Assert.AreEqual(CliArgsOptions.HelpArg.Name, singleSetArg.Name);
		}

		[TestMethod]
		public void BuildFromDefaultFormatWithRequestedHelpShortName()
		{
			string[] expectedArgs = new[] { "-h" };
			var mockedCLI = new Mock<IArgumentsProvider>();
			mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);

			ICliArgsContainer container = new CliArgsContainer()
			{
				ArgumentsProvider = mockedCLI.Object
			};

			ICliArgsSetup defaultSetup = new DefaultContainerSetup();
			defaultSetup.Configure(container);
			container.Register(CliArg.New<int>("test"));
			container.Register(CliArg.New<int>("other"));

			CliArgsBuilder.Build(container);

			var singleSetArg = container.GetArgs().ToList().SingleOrDefault(e => e.IsSet);
			Assert.IsNotNull(singleSetArg);
			Assert.AreEqual(CliArgsOptions.HelpArg.Name, singleSetArg.Name);
		}

		[TestMethod]
		public void BuildFromDefaultFormatWithNoRequiredValueSuccess()
		{
			string[] expectedArgs = new[] { "--no-value" }; 
			var mockedCLI = new Mock<IArgumentsProvider>();
			mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);

			ICliArgsContainer container = new CliArgsContainer()
			{
				ArgumentsProvider = mockedCLI.Object
			};

			ICliArgsSetup defaultSetup = new DefaultContainerSetup();
			defaultSetup.Configure(container);

			container.Register(CliArg.New<int>("test"));
			container.Register(CliArg.New<int>("other"));
			container.Register(CliArg.New("no-value"));

			CliArgsBuilder.Build(container);
			var test = container.GetCliArgByName("no-value");
			Assert.IsNotNull(test);
			Assert.IsTrue(test.IsSet);
		}

		[TestMethod]
		public void BuildFromCustomFormatWithNoRequiredValueSuccess()
		{
			string[] expectedArgs = new[] { "--no-value" };
			var mockedCLI = new Mock<IArgumentsProvider>();
			mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);

			ICliArgsContainer container = new CliArgsContainer(new CliArgsFormat('='))
			{
				ArgumentsProvider = mockedCLI.Object
			};

			ICliArgsSetup defaultSetup = new DefaultContainerSetup();
			defaultSetup.Configure(container);

			container.Register(CliArg.New<int>("test"));
			container.Register(CliArg.New<int>("other"));
			container.Register(CliArg.New("no-value"));

			CliArgsBuilder.Build(container);
			var test = container.GetCliArgByName("no-value");
			Assert.IsNotNull(test);
			Assert.IsTrue(test.IsSet);
		}
	}
}

