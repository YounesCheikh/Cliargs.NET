using System;
namespace Cliargs
{
	/// <summary>
    /// Command Line Interface Argument not found exception
    /// </summary>
	public class CLIArgumentNotFoundException : CliArgsException
	{
		/// <summary>
        /// The target argument name
        /// </summary>
		public string ArgumentName { get; }

		/// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="name">The target argument key</param>
		public CLIArgumentNotFoundException(string name) : base("Command Line Argument Not found")
		{
			this.ArgumentName = name;
		}
	}
}

