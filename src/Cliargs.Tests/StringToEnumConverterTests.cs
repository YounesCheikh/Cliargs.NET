using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class StringToEnumConverterTests
	{
		enum FakeEnum
        {
			ElementOne,
			ElementTwo,
			ElementThree
        }

		[TestMethod]
		public void SampleConversionTest()
        {
			StringToEnumConverter converter = new StringToEnumConverter();
			var obj = converter.GetConverted(typeof(FakeEnum), "ElementOne");
			Assert.IsNotNull(obj);
			Assert.AreEqual(typeof(FakeEnum), obj.GetType());

			obj = converter.GetConverted(typeof(FakeEnum), "ElementTwo");
			Assert.IsNotNull(obj);
			Assert.AreEqual(typeof(FakeEnum), obj.GetType());

			obj = converter.GetConverted(typeof(FakeEnum), "ElementThree");
			Assert.IsNotNull(obj);
			Assert.AreEqual(typeof(FakeEnum), obj.GetType());

			obj = converter.GetConverted(typeof(FakeEnum), "AnyOther");
			Assert.IsNull(obj);
		}

		[TestMethod]
		[ExpectedException(typeof(CliArgsException))]
		public void ExceptionThrownIfNotEnumType()
		{
			StringToEnumConverter converter = new StringToEnumConverter();
            _ = converter.GetConverted(typeof(int), "1");
        }
	}
}

