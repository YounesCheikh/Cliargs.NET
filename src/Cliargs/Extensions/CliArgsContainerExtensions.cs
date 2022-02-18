using System;
namespace Cliargs
{
	public static class CliArgsContainerExtensions
	{
		public static CliArg GetCliArgByName(this ICliArgsContainer container, string name)
        {
			var item= container.CliArgsRepository.CliArgs.Values.SingleOrDefault(e=> e.Name == name);
			if (item == null)
				throw new Exception($"Unable to find the argument having a name = {name}");
			return item;
		}

		public static CliArg GetCliArgByShortName(this ICliArgsContainer container, string shortName)
		{
			var item = container.CliArgsRepository.CliArgs.Values.SingleOrDefault(e => e.Info.ShortName == shortName);
			if (item == null)
				throw new Exception($"Unable to find the argument having a shortname = {shortName}");
			return item;
		}

		public static IEnumerable<CliArg> GetArgs(this ICliArgsContainer container)
        {
			return container.CliArgsRepository.CliArgs.Values;
        }
	}
}

