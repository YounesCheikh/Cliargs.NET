using System;
namespace Cliargs
{
	public interface IArgNamesGenerator
	{
		string GenerateLongName(string argName);

		string GenerateShortName(string argName);
	}
}

