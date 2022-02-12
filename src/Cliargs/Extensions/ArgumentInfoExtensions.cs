using System;
namespace Cliargs.Extensions
{
	public static class ArgumentInfoExtensions
	{
		public static ArgumentInfo WithShortName(this ArgumentInfo info, string shortName)
        {
			info.ShortName = shortName;
			return info;
        }

		public static ArgumentInfo WithDescription(this ArgumentInfo info, string description)
		{
			info.Description = description;
			return info;
		}

		public static ArgumentInfo WithUsage(this ArgumentInfo info, string usage)
		{
			info.Usage = usage;
			return info;
		}
	}
}

