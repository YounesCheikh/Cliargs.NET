using System;
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
		public void IntegerGreaterThanOtherTest()
		{
			var rule = new LessThanRule<int>(1);
			Assert.IsTrue(rule.IsValid(0));
			Assert.IsFalse(rule.IsValid(1));
			Assert.IsFalse(rule.IsValid(2));
		}

		[TestMethod]
		public void StringGreaterThanOtherTest()
		{
			var rule = new LessThanRule<string>("C");
			Assert.IsTrue(rule.IsValid("B"));
			Assert.IsFalse(rule.IsValid("D"));
			Assert.IsFalse(rule.IsValid("C"));
		}

		[TestMethod]
		public void EnumGreaterThanOtherTest()
		{
			var rule = new LessThanRule<FakeEnum>(FakeEnum.NumberTwo);
			Assert.IsTrue(rule.IsValid(FakeEnum.NumberOne));
			Assert.IsFalse(rule.IsValid(FakeEnum.NumberTwo));
			Assert.IsFalse(rule.IsValid(FakeEnum.NumberThree));
		}
	}
}

