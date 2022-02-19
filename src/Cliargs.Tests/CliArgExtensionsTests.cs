using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class CliArgExtensionsTests
	{
        class ZeroValidationRule : CliArgsValidationRule<int>
        {
            public override string GetValidationError()
            {
				return "Value must be zero";
            }

            public override bool IsValid(int value)
            {
				return value == 0;
            }
        }

        [TestMethod]
		public void CreateSampleInstanceWithDefaultInfo()
        {
			const string argName = "test";
			var arg = CliArg.New<int>(argName);
			Assert.IsNotNull(arg);
			Assert.IsNotNull(arg.Info);
			Assert.AreEqual(argName, arg.Name);
			Assert.IsFalse(arg.Info.Optional);
			Assert.AreEqual(string.Empty, arg.Info.ShortName);
			Assert.AreEqual(string.Empty, arg.Info.Description);
			Assert.AreEqual(string.Empty, arg.Info.Usage);
		}

		[TestMethod]
		public void CreateSampleInstanceWithShortname()
		{
			const string argName = "test";
			const string shortName = "t";
			var arg = CliArg.New<int>(argName).WithShortName(shortName);
			Assert.IsNotNull(arg);
			Assert.IsNotNull(arg.Info);
			Assert.AreEqual(shortName, arg.Info.ShortName);
		}

		[TestMethod]
		public void CreateSampleInstanceWithDescription()
		{
			const string argName = "test";
			const string description = "sample description";
			var arg = CliArg.New<int>(argName).WithDescription(description);
			Assert.IsNotNull(arg);
			Assert.IsNotNull(arg.Info);
			Assert.AreEqual(description, arg.Info.Description);
		}

		[TestMethod]
		public void CreateSampleInstanceWithUsage()
		{
			const string argName = "test";
			const string usage = "sample usage";
			var arg = CliArg.New<int>(argName).WithUsage(usage);
			Assert.IsNotNull(arg);
			Assert.IsNotNull(arg.Info);
			Assert.AreEqual(usage, arg.Info.Usage);
		}

		[TestMethod]
		public void CreateSampleInstanceAsRequired()
		{
			const string argName = "test";
			const bool optional = false;
			var arg = CliArg.New<int>(argName).AsRequired();
			Assert.IsNotNull(arg);
			Assert.IsNotNull(arg.Info);
			Assert.AreEqual(optional, arg.Info.Optional);
		}

		[TestMethod]
		public void CreateSampleInstanceAsOptional()
		{
			const string argName = "test";
			const bool optional = true;
			var arg = CliArg.New<int>(argName).AsOptional();
			Assert.IsNotNull(arg);
			Assert.IsNotNull(arg.Info);
			Assert.AreEqual(optional, arg.Info.Optional);
		}

		[TestMethod]
		public void CreateSampleInstanceWithValidationRule()
		{
			const string argName = "test";
			ZeroValidationRule rule = new ZeroValidationRule();
			var arg = CliArg.New<int>(argName).ValidatedWithRule(rule);
			Assert.IsNotNull(arg);
			Assert.IsTrue(arg.ValidationRules.Any());
			Assert.AreEqual(1, arg.ValidationRules.Count);
		}

		[TestMethod]
		public void CreateSampleInstanceWithValidationRules()
		{
			const string argName = "test";
			ZeroValidationRule rule = new ZeroValidationRule();
			var arg = CliArg.New<int>(argName).ValidatedWithRules(new [] { rule });
			Assert.IsNotNull(arg);
			Assert.IsTrue(arg.ValidationRules.Any());
			Assert.AreEqual(1, arg.ValidationRules.Count);
		}
	}
}

