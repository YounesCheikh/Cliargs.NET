using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cliargs.Rules;
using System.IO;

namespace Cliargs.Tests.Rules
{
    [TestClass]
    public class DirectoryExistsRuleTests
    {
        string localExistingDir = "test_dir";

        [TestInitialize]
        public void Init() {
            Directory.CreateDirectory(localExistingDir);
        }

        [TestCleanup]
        public void CleanUp() {
            if(Directory.Exists(localExistingDir))
                Directory.Delete(localExistingDir);
        }
        [TestMethod]
        public void DirectoryExistOnRelativePathTest() {
            var rule = new DirectoryExistsRule();
            Assert.IsTrue(rule.IsValid(localExistingDir));
            Assert.IsTrue(rule.IsValid($".{Path.AltDirectorySeparatorChar}{localExistingDir}"));    
        }

        [TestMethod]
        public void DirectoryExistOnAbsoluePathTest() {
            var rule = new DirectoryExistsRule();
            Assert.IsTrue(rule.IsValid(Path.Combine(Environment.CurrentDirectory, localExistingDir)));
        }

        [TestMethod]
        public void DirectoryNotExistOnRelativePathTest() {
            var rule = new DirectoryExistsRule();
            Assert.IsFalse(rule.IsValid("_"+localExistingDir));
            Assert.IsFalse(rule.IsValid($".{Path.AltDirectorySeparatorChar}_{localExistingDir}"));    
        }

        [TestMethod]
        public void DirectoryNotExistOnAbsoluePathTest() {
            var rule = new DirectoryExistsRule();
            Assert.IsFalse(rule.IsValid(Path.Combine(Environment.CurrentDirectory, "_"+localExistingDir)));
            Assert.IsTrue(rule.GetValidationError().Contains(localExistingDir));
        }

        [TestMethod]
        public void DirectoryWithNoValidPathTest() {
            var rule = new DirectoryExistsRule(); 
#pragma warning disable CS8625
            Assert.IsFalse(rule.IsValid(null));
#pragma warning restore CS8625
        }



    }
}