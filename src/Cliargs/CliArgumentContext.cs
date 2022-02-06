using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliargs
{
    public class CliArgumentContext
    {
        public CliArgumentContext(CliArgument argument)
        {
            this.Argument = argument;
        }
        
        public CliArgument Argument { get; set; } 
    }
}