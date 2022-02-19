using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cliargs.Rules;
using System;

namespace Cliargs.Tests;

[TestClass]
public class RangeValidationRuleTests {

    enum FakeEnum
    {
        ElementOne,
        ElementTwo,
        ElementThree
    }

    [TestMethod]
    public void SampleIntRangeSuccessTest() {
        RangeValidationRule<int?> rule = RangeValidationRule<int?>.FromRange(new int?[] { 1, 2, 3 });
        Assert.IsTrue(rule.IsValid(1));
        Assert.IsTrue(rule.IsValid(2));
        Assert.IsTrue(rule.IsValid(3));
        Assert.IsFalse(rule.IsValid(0));
        Assert.IsFalse(rule.IsValid(4));
        Assert.IsFalse(rule.IsValid(-1));
        Assert.IsFalse(rule.IsValid(null));
    }

    [TestMethod]
    public void SampleStringRangeSuccessTest()
    {
        RangeValidationRule<string?> rule = new RangeValidationRule<string?>(new string?[] { true.ToString().ToLower(), false.ToString().ToLower() });
        Assert.IsTrue(rule.IsValid("true".ToLower()));
        Assert.IsTrue(rule.IsValid("false".ToLower()));
        Assert.IsFalse(rule.IsValid("yes"));
        Assert.IsFalse(rule.IsValid("no"));
        Assert.IsFalse(rule.IsValid(""));
        Assert.IsFalse(rule.IsValid(default));
    }

    [TestMethod]
    public void SampleEnumRangeSuccessTest()
    {
        RangeValidationRule<FakeEnum?> rule = new RangeValidationRule<FakeEnum?>(new FakeEnum?[] { FakeEnum.ElementOne, FakeEnum.ElementThree });
        Assert.IsTrue(rule.IsValid(FakeEnum.ElementOne));
        Assert.IsTrue(rule.IsValid(FakeEnum.ElementThree));
        Assert.IsFalse(rule.IsValid(FakeEnum.ElementTwo));
        Assert.IsFalse(rule.IsValid(null));
    }

    [TestMethod]
    public void SampleEnumRangeErrorMexssageVerificationTest()
    {
        RangeValidationRule<FakeEnum?> rule = new RangeValidationRule<FakeEnum?>(new FakeEnum?[] { FakeEnum.ElementOne, FakeEnum.ElementThree });
        Assert.IsTrue(rule.GetValidationError().Contains(FakeEnum.ElementOne.ToString("G")));
        Assert.IsTrue(rule.GetValidationError().Contains(FakeEnum.ElementThree.ToString("G")));
        Assert.IsFalse(rule.GetValidationError().Contains(FakeEnum.ElementTwo.ToString("G")));
    }
} 
