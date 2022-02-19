using System;
using System.Linq;
using Cliargs.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class CliArgsValidatorTests
	{
		[TestMethod]
		public void ValidateEmptyContainerSuccessTest()
		{
			ICliArgsContainer container = new CliArgsContainer();
			var results = CliArgsValidator.Validate(container);
			Assert.IsFalse(results.Any());
		}

		[TestMethod]
		public void ValidateArgsWithoutRulesSuccessTest()
        {
			ICliArgsContainer container = new CliArgsContainer();
			var arg = CliArg.New<int>("test");
			arg.InputValue = "0";
			container.Register(arg);
			var results = CliArgsValidator.Validate(container);
			Assert.IsFalse(results.Any());
        }

		[TestMethod]
		public void ValidateArgsWithOneRuleSuccessTest() 
		{
			ICliArgsContainer container = new CliArgsContainer();
			var arg = CliArg.New<int>("test").ValidatedWithRule(RangeValidationRule<int>.FromRange(0));
			arg.InputValue = "0";
			container.Register(arg);
			var results = CliArgsValidator.Validate(container);
			Assert.IsFalse(results.Any());
		}

		[TestMethod]
		public void ValidateArgsWithOneRuleFailsTest()
		{
			ICliArgsContainer container = new CliArgsContainer();
			var arg = CliArg.New<int>("test").ValidatedWithRule(RangeValidationRule<int>.FromRange(0));
			arg.InputValue = "1";
			container.Register(arg);
			var results = CliArgsValidator.Validate(container);
			Assert.IsTrue(results.Any());
			Assert.AreEqual(1, results.Count);
		}

		[TestMethod]
		public void ValidateMultiArgsWithOneRuleStopsOnFirstFailureTest()
		{ 
			ICliArgsContainer container = new CliArgsContainer();
			var arg = CliArg.New<int>("test").ValidatedWithRule(RangeValidationRule<int>.FromRange(0));
			arg.InputValue = "1";
			container.Register(arg);

			var arg2 = CliArg.New<string>("test2").ValidatedWithRule(RangeValidationRule<string>.FromRange("0"));
			arg2.InputValue = "1";
			container.Register(arg2);

			var results = CliArgsValidator.Validate(container);
			Assert.IsTrue(results.Any());
			Assert.AreEqual(1, results.Count);
		}

		[TestMethod]
		public void ValidateArgWithMultiRuleFailureTest()
		{
			ICliArgsContainer container = new CliArgsContainer();
			var arg = CliArg.New<int>("test").ValidatedWithRules(
				new LessThanOrEqualsRule<int>(12),
				RangeValidationRule<int>.FromRange(10, 9, 8)
				);
			arg.InputValue = "13";
			container.Register(arg);

			var results = CliArgsValidator.Validate(container);
			Assert.IsTrue(results.Any());

			// 13 is greater than 12
			// and 13 is not in range 8, 9, 10
			Assert.AreEqual(2, results.Count);
		}
	}
}

