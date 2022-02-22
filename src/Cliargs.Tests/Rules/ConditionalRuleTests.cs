using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cliargs.Rules;
namespace Cliargs.Tests.Rules
{
    [TestClass]
    public class ConditionalRuleTests
    {
        [TestMethod]
        public void CreateConditionalRuleWithDefaultValidationError(){
#pragma warning disable CS8625
            var defaultRule = new ConditionalRule<int>(null);
#pragma warning restore CS8625

            var rule = ConditionalRule<int>.WithCondition(v=> v> 0);
            Assert.IsNotNull(rule);
            Assert.IsTrue(rule.IsValid(1));
            Assert.IsFalse(rule.IsValid(0));
            Assert.AreEqual(defaultRule.GetValidationError(), rule.GetValidationError());
        }

        [TestMethod]
        public void CreateConditionalRuleWithCustomValidationError(){
#pragma warning disable CS8625
            var defaultRule = new ConditionalRule<int>(null);
#pragma warning restore CS8625
            var customError = "Value must be greater than 0";
            var rule = ConditionalRule<int>.WithCondition(v=> v> 0).WithValidationError(customError);
            Assert.IsNotNull(rule);
            Assert.IsTrue(rule.IsValid(1));
            Assert.IsFalse(rule.IsValid(0));
            Assert.AreNotEqual(defaultRule.GetValidationError(), rule.GetValidationError());
            Assert.AreEqual(customError, rule.GetValidationError());
        }
    }
}