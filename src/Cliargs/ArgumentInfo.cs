using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliargs
{
    public class ArgumentInfo
    { 
        public ArgumentInfo(string name, bool optional)
        {
            this.Name = name;
            this.Optional = optional;
        }

        /// <summary>
        /// The argument name
        /// </summary>
        /// <value>Argument name as set, default is empty string</value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Short argument name
        /// </summary>
        /// <value>The short name for the argument, default is empty string</value>
        public string ShortName { get; set; } = string.Empty;

        /// <summary>
        /// The argument description
        /// </summary>
        /// <value>The argument description</value>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Argument usage example, this is shown to user when a wrong value is entered.
        /// </summary>
        /// <value>The usage string value</value>
        public string Usage { get; set; } = string.Empty;

        /// <summary>
        /// Define if argument is option
        /// </summary>
        /// <value>true if argument is optional, otherwise false.</value>
        public bool Optional { get; set; } = true;

        public static ArgumentInfo New(string name, bool optional = true)
        {
            return new ArgumentInfo(name, optional);
        }
    }
}