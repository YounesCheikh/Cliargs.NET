using System.Text.RegularExpressions;
using Cliargs.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests.Rules
{
    [TestClass]
    public class RegexRuleTests
    {
        [TestMethod]
        public void CreateRuleWithValidationError() {
            const string validationError = "The value doesn't match the defined pattern.";
            const string pattern = ".*";
            RegexRule regexRule = RegexRule.WithPattern(pattern)
            .WithValidationError(validationError);
            Assert.IsNotNull(regexRule);  
            var ruleValidationError = regexRule.GetValidationError();
            Assert.AreEqual(validationError, ruleValidationError); 
        }

        [TestMethod]
        [ExpectedException(typeof(CliArgsException))]
        [Description("The constructor of the rule is throwing an exception when an invalid pattern is set")]
        public void CreateRuleWithWrongPattern() 
        {
            const string pattern = "[]";
            RegexRule regexRule = new RegexRule(pattern);
            Assert.IsNotNull(regexRule);  
        }

        [TestMethod]
        [ExpectedException(typeof(CliArgsException))]
        [Description("The constructor of the rule is throwing an exception when an invalid pattern is set")]
        public void CreateRuleWithOptionsAndWrongPattern() 
        {
            const string pattern = "[]";
            RegexRule regexRule = new RegexRule(pattern, RegexOptions.None);
            Assert.IsNotNull(regexRule);  
        }

        [TestMethod]
        public void CreateRuleWithAnyMatch() {
            const string pattern = ".*";
            RegexRule regexRule = RegexRule
            .WithPattern(pattern);
            Assert.IsNotNull(regexRule);  
            Assert.IsTrue(regexRule.IsValid("Hello world!"));
        }

        [TestMethod]
        public void CreateRuleWithOnlyDigitMatch() {
            const string pattern = @"\d";
            RegexRule regexRule = RegexRule.WithPattern(pattern);
            Assert.IsNotNull(regexRule);  
            Assert.IsFalse(regexRule.IsValid("Hello world!"));
            Assert.IsTrue(regexRule.IsValid("123"));
        }

        [TestMethod]
        public void CreateRuleWithUpperCaseIgnored() {
            const string pattern = @"[a-z]";
            RegexRule regexRule = RegexRule.WithPattern(pattern, RegexOptions.IgnoreCase);
            Assert.IsNotNull(regexRule);  
            Assert.IsFalse(regexRule.IsValid("1"));
            Assert.IsTrue(regexRule.IsValid("c"));
            Assert.IsTrue(regexRule.IsValid("C"));
        }

        [TestMethod]
        public void CreateRuleWithLowerCaseStrict() {
            const string pattern = @"[a-z]";
            RegexRule regexRule = RegexRule.WithPattern(pattern, RegexOptions.None);
            Assert.IsNotNull(regexRule);  
            Assert.IsFalse(regexRule.IsValid("1"));
            Assert.IsTrue(regexRule.IsValid("c"));
            Assert.IsFalse(regexRule.IsValid("C"));
        }
    }
}