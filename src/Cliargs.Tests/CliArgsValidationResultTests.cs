using System;
using Cliargs.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class CliArgsValidationResultTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ArgumentNullExceptionThrownIfInfoIsNull()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _ = new CliArgsValidationResult(RangeValidationRule<int>.FromRange(), null, false);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ArgumentNullExceptionThrownIfRuleIsNull()
		{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
			_ = new CliArgsValidationResult(null, CliArgsInfo.New("test"), false);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
		}

		[TestMethod]
		public void InfoAndRulePropertiesAttachedToResult()
        {
			var info = CliArg.New<int>("test").WithUsage("Sample Usage").Info;
			var rule = RangeValidationRule<int>.FromRange(0);
			var ruleName = rule.GetType().GetNameWithoutGenericArity();
			var result = new CliArgsValidationResult(rule, info, false);
			Assert.AreEqual(info.Name, result.ArgName);
			Assert.AreEqual(info.Usage, result.Usage);
			Assert.AreEqual(rule.GetValidationError(), result.ValidationError);
			Assert.AreEqual(ruleName, result.RuleName);

			Assert.IsTrue(result.GetReport().Contains(info.Usage));
			Assert.IsTrue(result.GetReport().Contains(info.Name));
			Assert.IsTrue(result.GetReport().Contains(ruleName));
			Assert.IsTrue(result.GetReport().Contains(rule.GetValidationError()));
		}
	}

}

