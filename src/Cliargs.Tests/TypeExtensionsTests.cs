using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cliargs.Tests
{
	[TestClass]
	public class TypeExtensionsTests
	{
        class Fake<T> { }

		[TestMethod]
		public void GetNameWithoutGenericArityTest()
        {
			var nameWithoutGenericArity = typeof(Fake<int>).GetNameWithoutGenericArity();
			var name = typeof(Fake<int>).Name;
			Assert.AreEqual("Fake", nameWithoutGenericArity);
			Assert.AreNotEqual("Fake", name);
			Console.WriteLine(name);
		}

		[TestMethod]
		public void GetNameWithoutGenericOfGenericArityTest()
		{
			var nameWithoutGenericArity = typeof(Fake<Fake<int>>).GetNameWithoutGenericArity();
			var name = typeof(Fake<Fake<int>>).Name;
			Assert.AreEqual("Fake", nameWithoutGenericArity);
			Assert.AreNotEqual("Fake", name);
			Console.WriteLine(name);
		}
	}
}

