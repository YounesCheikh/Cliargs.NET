using System;
using Cliargs.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests.Rules
{
	[TestClass]
	public class EqualsRuleTest
	{
		enum FakeEnum
        {
			Element1,
			Element2
        }

		[TestMethod]
		public void IntEqualsRuleTest()
        {
			var rule = new EqualsRule<int>(3);
			Assert.IsTrue(rule.IsValid(3));
			Assert.IsFalse(rule.IsValid(-3));
		}

		[TestMethod]
		public void StringEqualsRuleTest()
		{
			var rule = new EqualsRule<string>("Sample String");
			Assert.IsTrue(rule.IsValid("Sample String"));
			Assert.IsFalse(rule.IsValid("Another String"));
			Assert.IsFalse(rule.IsValid(""));
		}

		[TestMethod]
		public void EnumEqualsRuleTest()
		{
			var rule = new EqualsRule<FakeEnum>(FakeEnum.Element1);
			Assert.IsTrue(rule.IsValid(FakeEnum.Element1));
			Assert.IsFalse(rule.IsValid(FakeEnum.Element2));
		}

		[TestMethod]
		public void VerifyErrorMessageContainsTheValue()
		{
			var rule = new EqualsRule<FakeEnum>(FakeEnum.Element1);
			Assert.IsTrue(rule.GetValidationError().Contains(FakeEnum.Element1.ToString("G")));
		}
	}
}

