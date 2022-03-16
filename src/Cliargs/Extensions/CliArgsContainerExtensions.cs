using System;
using System.Collections.Generic;
using System.Linq;

namespace Cliargs
{
	static class CliArgsContainerExtensions
	{
		public static CliArg? GetCliArgByName(this ICliArgsContainer container, string name)
        {
			var item= container.CliArgs.Values.SingleOrDefault(e=> e.Name == name);
			return item;
		}

		public static CliArg? GetCliArgByLongName(this ICliArgsContainer container, string longName)
		{
			var item = container.CliArgs.Values.SingleOrDefault(e => e.Info.LongName == longName);
			return item;
		}

		public static CliArg? GetCliArgByShortName(this ICliArgsContainer container, string shortName)
		{
			var item = container.CliArgs.Values.SingleOrDefault(e => e.Info.ShortName == shortName);
			return item;
		}

		public static IEnumerable<CliArg> GetArgs(this ICliArgsContainer container)
        {
			return container.CliArgs.Values;
        }
	}
}

