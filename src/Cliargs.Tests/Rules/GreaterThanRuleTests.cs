using Cliargs.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests.Rules
{
    [TestClass]
	public class GreaterThanRuleTests
	{
		enum FakeEnum
        {
			NumberOne,
			NumberTwo,
			NumberThree
        }

		[TestMethod]
		public void IntegerGreaterThanOtherTest()
        {
			var rule = new GreaterThanRule<int>(1);
			Assert.IsTrue(rule.IsValid(2));
			Assert.IsFalse(rule.IsValid(1));
			Assert.IsFalse(rule.IsValid(0));
		}

		[TestMethod]
		public void IntegerGreaterThanOrEqualsOtherTest()
		{
			var rule = new GreaterThanOrEqualsRule<int>(1);
			Assert.IsTrue(rule.IsValid(2));
			Assert.IsTrue(rule.IsValid(1));
			Assert.IsFalse(rule.IsValid(0));
		}

		[TestMethod]
		public void StringGreaterThanOtherTest()
		{
			var rule = new GreaterThanRule<string>("C");
			Assert.IsTrue(rule.IsValid("D"));
			Assert.IsFalse(rule.IsValid("A"));
			Assert.IsFalse(rule.IsValid("C"));
		}

		[TestMethod]
		public void EnumGreaterThanOtherTest()
		{ 
			var rule = new GreaterThanRule<FakeEnum>(FakeEnum.NumberTwo);
			Assert.IsTrue(rule.IsValid(FakeEnum.NumberThree));
			Assert.IsFalse(rule.IsValid(FakeEnum.NumberTwo));
			Assert.IsFalse(rule.IsValid(FakeEnum.NumberOne));
		}

		[TestMethod]
		public void VerifyErrorMessageContainsTheValue()
		{
			var rule = new GreaterThanRule<FakeEnum>(FakeEnum.NumberTwo);
			Assert.IsTrue(rule.GetValidationError().Contains(FakeEnum.NumberTwo.ToString("G")));

			var ruleOrEquals = new GreaterThanOrEqualsRule<FakeEnum>(FakeEnum.NumberTwo);
			Assert.IsTrue(ruleOrEquals.GetValidationError().Contains(FakeEnum.NumberTwo.ToString("G")));
		}
	}
}

