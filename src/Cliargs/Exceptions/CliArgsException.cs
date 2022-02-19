using System;
namespace Cliargs
{
	public class CliArgsException: Exception
	{
        public CliArgsException()
        {

        }

        public CliArgsException(string message): base(message)
        {

        }
	}
}

