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
            public CustomFormat(char assignationChar, string longNamePrefix, string shortNamePrefix): base(assignationChar, longNamePrefix, shortNamePrefix) { }
        }


		[TestMethod]
		public void CustomFormatNotChangingTest()
        {
            CustomFormat customFormat = new CustomFormat();
            Assert.AreEqual(CliArgsFormat.Default.AssignationChar, customFormat.AssignationChar);
            Assert.AreEqual(CliArgsFormat.Default.LongNamePrefix, customFormat.LongNamePrefix);
            Assert.AreEqual(CliArgsFormat.Default.ShortNamePrefix, customFormat.ShortNamePrefix);
        }

        [TestMethod]
        public void CustomFormatCustomAssignationCharTest()
        {
            CustomFormat customFormat = new CustomFormat('='); 
            Assert.AreEqual('=', customFormat.AssignationChar);
            Assert.AreEqual(CliArgsFormat.Default.LongNamePrefix, customFormat.LongNamePrefix);
            Assert.AreEqual(CliArgsFormat.Default.ShortNamePrefix, customFormat.ShortNamePrefix);
        }

        [TestMethod]
        public void FullCustomFormatTest()
        {
            CustomFormat customFormat = new CustomFormat('=', ":", "/");
            Assert.AreEqual('=', customFormat.AssignationChar);
            Assert.AreEqual(":", customFormat.LongNamePrefix);
            Assert.AreEqual("/", customFormat.ShortNamePrefix);
        }
    }
}

