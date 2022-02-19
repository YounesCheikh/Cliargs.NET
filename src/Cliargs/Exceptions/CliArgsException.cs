using System;
namespace Cliargs
{
	public class CliArgsException: Exception
	{
        public CliArgsException()
        {

        }

        public CliArgsException(string? message): base(message)
        {

        }

        public CliArgsException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}

