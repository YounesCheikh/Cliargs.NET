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
			var value = converter.ConvertFromString<int>(inputValue);
			Assert.AreEqual(1, value);

			inputValue = "-1";
			value = converter.ConvertFromString<int>(inputValue);
			Assert.AreEqual(-1, value);
		}

		[TestMethod, TestCategory("Conversion"), Description("Test the conversion from string to int")]
		[ExpectedException(typeof(FormatException))]
		public void ConvertToIntFailTest()
		{
			var converter = ValueTypeConverter.Default;
			string inputValue = "Hello";
			converter.ConvertFromString<int>(inputValue);
		}

		[TestMethod, TestCategory("Conversion"), Description("Test the conversion from string to enum")]
		public void ConvertToEnumSuccessTest()
		{
			var converter = ValueTypeConverter.Default;
			string inputValue = "Element";
			var value = converter.ConvertFromString<FakeEnum>(inputValue);
			Assert.AreEqual(FakeEnum.Element, value);

			inputValue = "SecondElement";
			value = converter.ConvertFromString<FakeEnum>(inputValue);
			Assert.AreEqual(FakeEnum.SecondElement, value);

			inputValue = "AnotherOne";
			value = converter.ConvertFromString<FakeEnum>(inputValue);
			Assert.AreEqual(FakeEnum.AnotherOne, value);
		}

		[TestMethod, TestCategory("Conversion"), Description("Test the conversion from string to enum")]
		public void ConvertToEnumFailTest()
		{ 
			var converter = ValueTypeConverter.Default;
			string inputValue = "NoElement";
			var value = converter.ConvertFromString<FakeEnum>(inputValue);
			Console.WriteLine(value);
			Assert.AreEqual(default, value);
		}
	}
}

