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

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public CliArgsException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}

