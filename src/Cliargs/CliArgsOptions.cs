using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliargs
{
    public static class CliArgsOptions
    {
        public static class HelpArg {
            public static string Name {get;set;} = "Help";
            public static string LongName {get;set;} = "help";
            public static string ShortName {get;set;} = "h";
        }

        public static class Container {
            public static bool AutoGenerateNames { get; set; } = false;
        }
    }
}