using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class CliArgsContainerTests
	{
		[TestMethod]
		public void DefaultFormatAppliedTest()
		{
			CliArgsContainer container = new CliArgsContainer();
			Assert.IsNotNull(container.Format);
			Assert.AreEqual(CliArgsFormat.Default.AssignationChar, container.Format.AssignationChar);
			Assert.AreEqual(CliArgsFormat.Default.NamePrefix, container.Format.NamePrefix);
			Assert.AreEqual(CliArgsFormat.Default.ShortNamePrefix, container.Format.ShortNamePrefix);
			Assert.AreEqual(CliArgsFormat.Default.GetHashCode(), container.Format.GetHashCode());
		}

		[TestMethod]
		public void RegisterArgTest()
        {
			CliArgsContainer container = new CliArgsContainer();
            CliArg arg = CliArg<int>.New("test");
            container.Register(arg);
			Assert.IsTrue(container.CliArgs.ContainsKey("test"));
        }
	}
}

