using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class ValueTypeConverterTests
	{
		enum FakeEnum
        {
			Element,
			SecondElement,
			AnotherOne
        }

		[TestMethod, TestCategory("Conversion"), Description("Test the conversion from string to int")]
		public void ConvertToIntSuccessTest()
        {
			var converter = ValueTypeConverter.Default;
			string inputValue = "1";
			var value = converter.GetConverted(typeof(int), inputValue);
			Assert.AreEqual(1, value);

			inputValue = "-1";
			value = converter.GetConverted(typeof(int), inputValue);
			Assert.AreEqual(-1, value);
		}

		[TestMethod, TestCategory("Conversion"), Description("Test the conversion from string to int")]
		public void ConvertToIntFailTest()
		{
			var converter = ValueTypeConverter.Default;
			string inputValue = "Hello";
			Assert.IsNull(converter.GetConverted(typeof(int), inputValue));
		}

		[TestMethod, TestCategory("Conversion"), Description("Test the conversion from string to enum")]
		public void ConvertToEnumSuccessTest()
		{
			var converter = new StringToEnumConverter();
			string inputValue = "Element";
			var value = converter.GetConverted(typeof(FakeEnum), inputValue);
			Assert.AreEqual(FakeEnum.Element, value);

			inputValue = "SecondElement";
			value = converter.GetConverted(typeof(FakeEnum), inputValue);
			Assert.AreEqual(FakeEnum.SecondElement, value);

			inputValue = "AnotherOne";
			value = converter.GetConverted(typeof(FakeEnum), inputValue);
			Assert.AreEqual(FakeEnum.AnotherOne, value);
		}

		[TestMethod, TestCategory("Conversion"), Description("Test the conversion from string to enum")]
		public void ConvertToEnumFailTest()
		{
			var converter = new StringToEnumConverter();
			string inputValue = "NoElement";
			var result = converter.GetConverted(typeof(FakeEnum), inputValue);
			Assert.IsNull(result);
		}
	}
}

