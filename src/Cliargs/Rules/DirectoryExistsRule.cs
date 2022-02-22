using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliargs.Rules
{
    public class DirectoryExistsRule : CliArgsValidationRule<string>
    {
        string _directory = string.Empty ;
        public override string GetValidationError()
        {
            return $"Directory {_directory} doesn't exist";
        }

        public override bool IsValid(string value)
        {
            try
            {
                _directory = value;
                var dirPath = string.Empty;
                if(Path.IsPathRooted(value))
                    dirPath = value;
                else dirPath = Path.Combine(Environment.CurrentDirectory, value);

                _directory = dirPath;
                return Directory.Exists(dirPath);
            }
            catch
            {
                return false;
            }
        }
    }
}