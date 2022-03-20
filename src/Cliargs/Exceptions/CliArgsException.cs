using System;
namespace Cliargs
{
    /// <summary>
    /// Command Line Interface Arguments Exception
    /// </summary>
	public class CliArgsException: Exception
	{
        /// <summary>
        /// Create new instance
        /// </summary>
        /// <param name="message">The message</param>
        public CliArgsException(string? message): base(message)
        {

        }

        public CliArgsException(string? message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

