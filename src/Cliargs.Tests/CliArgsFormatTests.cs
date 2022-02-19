using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class CliArgsFormatTests
	{
        private class CustomFormat : CliArgsFormat
        {
            public CustomFormat(): base(CliArgsFormat.Default.AssignationChar) { }
            public CustomFormat(char assignationChar): base(assignationChar) { }
            public CustomFormat(char assignationChar, string namePrefix, string shortNamePrefix): base(assignationChar, namePrefix, shortNamePrefix) { }
        }


		[TestMethod]
		public void CustomFormatNotChangingTest()
        {
            CustomFormat customFormat = new CustomFormat();
            Assert.AreEqual(CliArgsFormat.Default.AssignationChar, customFormat.AssignationChar);
            Assert.AreEqual(CliArgsFormat.Default.NamePrefix, customFormat.NamePrefix);
            Assert.AreEqual(CliArgsFormat.Default.ShortNamePrefix, customFormat.ShortNamePrefix);
        }

        [TestMethod]
        public void CustomFormatCustomAssignationCharTest()
        {
            CustomFormat customFormat = new CustomFormat('='); 
            Assert.AreEqual('=', customFormat.AssignationChar);
            Assert.AreEqual(CliArgsFormat.Default.NamePrefix, customFormat.NamePrefix);
            Assert.AreEqual(CliArgsFormat.Default.ShortNamePrefix, customFormat.ShortNamePrefix);
        }

        [TestMethod]
        public void FullCustomFormatTest()
        {
            CustomFormat customFormat = new CustomFormat('=', ":", "/");
            Assert.AreEqual('=', customFormat.AssignationChar);
            Assert.AreEqual(":", customFormat.NamePrefix);
            Assert.AreEqual("/", customFormat.ShortNamePrefix);
        }
    }
}

