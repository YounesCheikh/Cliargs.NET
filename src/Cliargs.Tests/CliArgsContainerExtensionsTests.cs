using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class CliArgsContainerExtensionsTests
	{

		[TestMethod]
		public void GetAllArgsTest()
        {
			ICliArgsContainer container = new CliArgsContainer();
			container.Register(CliArg.New<int>("test"));
			var gotArgs = container.GetArgs().ToList();
			Assert.IsTrue(gotArgs.Any());
			Assert.AreEqual(1, gotArgs.Count);
        }

		[TestMethod]
		public void GetExistingArgByNameTest()
        {
			ICliArgsContainer container = new CliArgsContainer();
			container.Register(CliArg.New<int>("test"));
			var arg = container.GetCliArgByName("test");
			Assert.IsNotNull(arg);
		}

		[TestMethod]
		public void GetNonExistingArgByNameTest()
		{
			ICliArgsContainer container = new CliArgsContainer();
			Assert.IsNull(container.GetCliArgByName("test"));
		}

		[TestMethod]
		public void GetExistingArgByShortNameTest()
		{
			ICliArgsContainer container = new CliArgsContainer();
			container.Register(CliArg.New<int>("test").WithShortName("t"));
			var arg = container.GetCliArgByShortName("t");
			Assert.IsNotNull(arg);
		}

		[TestMethod]
		public void GetNonExistingArgByShortNameTest()
		{
			ICliArgsContainer container = new CliArgsContainer();
			container.Register(CliArg.New<int>("test"));
			Assert.IsNull(container.GetCliArgByShortName("t"));
		}

		[TestMethod]
		public void GetNonExistingArgByShortNameFromEmptyContainerTest()
		{ 
			ICliArgsContainer container = new CliArgsContainer();
			Assert.IsNull(container.GetCliArgByShortName("t"));
		}
	}
}

