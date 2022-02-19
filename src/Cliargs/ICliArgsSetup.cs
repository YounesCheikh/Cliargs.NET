using System;
namespace Cliargs
{
	/// <summary>
    /// The Command Line interface arguments setup
    /// </summary>
	public interface ICliArgsSetup
	{
		/// <summary>
        /// Configure the Command Line Interface arguments container 
        /// </summary>
        /// <param name="container">The command line interface arguments container</param>
		void Configure(ICliArgsContainer container);
	}
}

