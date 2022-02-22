using Cliargs.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests.Rules
{
	[TestClass]
	public class LessThanRuleTests
	{
		enum FakeEnum
		{
			NumberOne,
			NumberTwo,
			NumberThree
		}

		[TestMethod]
		public void IntegerLessThanOtherTest()
		{
			var rule = LessThanRule<int>.Value(1);
			Assert.IsTrue(rule.IsValid(0));
			Assert.IsFalse(rule.IsValid(1));
			Assert.IsFalse(rule.IsValid(2));
		}

		[TestMethod]
		public void IntegerLessThanOrEqualsOtherTest()
		{
			var rule = LessThanOrEqualsRule<int>.Value(1);
			Assert.IsTrue(rule.IsValid(0));
			Assert.IsTrue(rule.IsValid(1));
			Assert.IsFalse(rule.IsValid(2));
		}

		[TestMethod]
		public void StringLessThanOtherTest()
		{
			var rule = new LessThanRule<string>("C");
			Assert.IsTrue(rule.IsValid("B"));
			Assert.IsFalse(rule.IsValid("D"));
			Assert.IsFalse(rule.IsValid("C"));
		}

		[TestMethod]
		public void EnumLessThanOtherTest()
		{
			var rule = new LessThanRule<FakeEnum>(FakeEnum.NumberTwo);
			Assert.IsTrue(rule.IsValid(FakeEnum.NumberOne));
			Assert.IsFalse(rule.IsValid(FakeEnum.NumberTwo));
			Assert.IsFalse(rule.IsValid(FakeEnum.NumberThree));
		}

		[TestMethod]
		public void VerifyErrorMessageContainsTheValue()
		{
			var rule = new LessThanRule<FakeEnum>(FakeEnum.NumberTwo);
			Assert.IsTrue(rule.GetValidationError().Contains(FakeEnum.NumberTwo.ToString("G")));

			var ruleOrEquals = new LessThanOrEqualsRule<FakeEnum>(FakeEnum.NumberTwo);
			Assert.IsTrue(ruleOrEquals.GetValidationError().Contains(FakeEnum.NumberTwo.ToString("G")));
		}
	}
}

