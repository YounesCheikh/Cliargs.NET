using System;
namespace Cliargs
{
    /// <summary>
    /// The command line interface argument information
    /// </summary>
	public class CliArgsInfo
	{
        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="name">The argument name</param>
        public CliArgsInfo(string name)
        {
            this.Name = name;
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
        /// Short argument name
        /// </summary>
        /// <value>The short name for the argument, default is empty string</value>
        public string LongName { get; set; } = string.Empty;

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
        /// Define if argument is optional or required
        /// </summary>
        /// <value>true if argument is optional, otherwise false.</value>
        public bool Optional { get; set; } = false;

        /// <summary>
        /// Indicates if the argument requires a value or not
        /// </summary>
        public bool RequiresValue { get; internal set; } = true;

        /// <summary>
        /// Create a new instance 
        /// </summary>
        /// <param name="name">The argument name</param>
        /// <param name="optional">indicates if the argument is required or optional.</param>
        /// <returns>The argument information</returns>
        public static CliArgsInfo New(string name, bool optional = false)
        {
            return new CliArgsInfo(name)
            {
                Optional = optional
            };
        }
    }
}

