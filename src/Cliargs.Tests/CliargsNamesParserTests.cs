using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cliargs.Tests
{
    [TestClass]
    public class CliargsNamesParserTests
    {
        const string SampleName = "John Doe";
        const int SampleAge = 30;

        public class SampleArgsObj {
            [CliArgName(nameof(Name))]
            public string? Name { get; set; }

            [CliArgName]
            public int Age {get;set;}

            [CliArgName()]
            public string? City { get; set; }

            public object? OtherProperty { get; set; }
        }

        public class WrongTypeArgsObj
        {
            [CliArgName(nameof(Name))]
            public bool? Name { get; set; }

            [CliArgName]
            public string? Age { get; set; }
        }

        public class NonDefinedKeysObj : SampleArgsObj
        {
            [CliArgName(nameof(Country))]
            public string Country { get; set; } = string.Empty;
        }


        class SampleSetup : ICliArgsSetup
        {
            public void Configure(ICliArgsContainer container)
            {
				string[] expectedArgs = new[] { "--name", SampleName, "--age", SampleAge.ToString() };
				var mockedCLI = new Mock<IArgumentsProvider>();
				mockedCLI.Setup(m => m.GetCommandLineArgs()).Returns(expectedArgs);
				container.ArgumentsProvider = mockedCLI.Object;
				ICliArgsSetup defaultSetup = new DefaultContainerSetup();
				container.Register(CliArg.New<string>(nameof(SampleArgsObj.Name)).WithLongName("name"));
				container.Register(CliArg.New<int>(nameof(SampleArgsObj.Age)).WithLongName("age").AsOptional());
                container.Register(CliArg.New<string>(nameof(SampleArgsObj.City)).AsOptional("Toulouse").WithLongName("city"));
            }
        }
        
        [TestMethod]
        public void ParseKeysTest() {
            ICliArgsSetup setup = new SampleSetup();
            ICliArgsContainer container = new CliArgsContainer();
            setup.Configure(container);
            CliArgsBuilder.Build(container);
            CliArgsValidator.Validate(container);
            

            var name = container.GetValue<string>(nameof(SampleArgsObj.Name));
            Assert.AreEqual(SampleName, name);
            var age = container.GetValue<int>(nameof(SampleArgsObj.Age));
            Assert.AreEqual(SampleAge, age);

            ICliargsNamesParser parser = new CliargsNamesParser(container);
            SampleArgsObj obj = parser.Parse<SampleArgsObj>();
            Assert.IsNotNull(obj);
            Assert.AreEqual(name, obj.Name);
            Assert.AreEqual(age, obj.Age);
        }

        [TestMethod]
        [ExpectedException(typeof(CliArgsException))]
        public void ParseNonDefinedKeyTest()
        {
            ICliArgsSetup setup = new SampleSetup();
            ICliArgsContainer container = new CliArgsContainer();
            setup.Configure(container);
            CliArgsBuilder.Build(container);
            CliArgsValidator.Validate(container);


            var name = container.GetValue<string>(nameof(SampleArgsObj.Name));
            Assert.AreEqual(SampleName, name);
            var age = container.GetValue<int>(nameof(SampleArgsObj.Age));
            Assert.AreEqual(SampleAge, age);

            ICliargsNamesParser parser = new CliargsNamesParser(container);
            _ = parser.Parse<NonDefinedKeysObj>();
        }

        [TestMethod]
        [ExpectedException(typeof(CliArgsException))]
        public void ParseIntoWrongTypedObjTest()
        {
            ICliArgsSetup setup = new SampleSetup();
            ICliArgsContainer container = new CliArgsContainer();
            setup.Configure(container);
            CliArgsBuilder.Build(container);
            CliArgsValidator.Validate(container);

            ICliargsNamesParser parser = new CliargsNamesParser(container);
            try
            {
                _ = parser.Parse<WrongTypeArgsObj>();
            }
            catch(CliArgsException exception)
            {
                Assert.IsNotNull(exception.InnerException);
                Assert.AreEqual(typeof(ArgumentException), exception.InnerException.GetType());
                throw exception;
            }
            
        }
    }
}