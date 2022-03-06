using System;
using System.Linq;
using Cliargs.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class CliArgTests
	{

		[TestMethod]
		public void GetValueTest()
		{
			var arg = CliArg.New<int>("test");
			arg.Value = 10;
			var nonGeneric = arg as CliArg;
			var value = nonGeneric.GetValue();
			Assert.AreEqual(arg.Value, value);
		}

		[TestMethod]
		public void GetDefaultValueTest()
		{
			var arg = CliArg.New("test");
			Assert.AreEqual(false, arg.GetValue());
		}

		[TestMethod]
		public void ValidateOptionalMissingArgumentTest()
        { 
			var arg = CliArg.New<int>("test").AsOptional(); 
			var results = arg.Validate();
			Assert.IsFalse(results.Any());
        }

		[TestMethod]
		public void ValidateRequiredMissingArgumentTest()
		{
			var arg = CliArg.New<int>("test").AsRequired();
			var results = arg.Validate();
			Assert.IsTrue(results.Any());
			Assert.AreEqual(1, results.Count);
			var uniqueResult = results.Single();
			Assert.AreEqual(nameof(NonNullArgumentRule), uniqueResult.RuleName);
		}

		[TestMethod]
		public void ValidateArgSampleTest()
		{
			var arg = CliArg.New<int>("test").AsOptional();
			arg.InputValue = "1";
			var results = arg.Validate();
			Assert.IsFalse(results.Any());
			Assert.AreEqual(1, arg.Value);

			Assert.IsFalse(CliArg.New("no-value").Validate().Any());
		}

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void ValidateArgFailureTest()
		{
			var arg = CliArg.New<int>("test").AsOptional();
			// Here is expected an integer instead of a boolean
			arg.InputValue = "true";
			var results = arg.Validate();
			Assert.IsTrue(results.Any());
		}
	}
}

