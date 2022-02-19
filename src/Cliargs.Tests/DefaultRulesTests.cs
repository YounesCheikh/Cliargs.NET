using System;
using Cliargs.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class DefaultRulesTests
	{
		[TestMethod]
		public void NonNullArgumentRuleErrorTest()
        {
			NonNullArgumentRule rule = new NonNullArgumentRule();
			Assert.IsFalse(string.IsNullOrWhiteSpace(rule.GetValidationError()));
        }
	}
}

