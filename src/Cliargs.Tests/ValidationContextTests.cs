using Cliargs.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests;

[TestClass]
public class ValidationContextTests
{
    [TestMethod]
    public void TypeValidationTest()
    {
        ArgValidationContext<int> context = ArgValidationContext<int>.New(ArgumentInfo.New("key"));
        context.AddRule(new RangeValidationRule<int>(new [] {1,2,3}));

        Assert.IsTrue(context.IsValid(1));
        Assert.IsTrue(context.IsValid(2));
        Assert.IsTrue(context.IsValid(3));
        Assert.IsFalse(context.IsValid(4));
    }
}