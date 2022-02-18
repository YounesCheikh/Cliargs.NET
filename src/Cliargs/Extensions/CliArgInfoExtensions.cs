using System;
namespace Cliargs
{
	public static class CliArgInfoExtensions
	{
		/// <summary>
        /// Set CLI Argument as required
        /// </summary>
        /// <param name="info"></param>
        /// <returns>The CLI argument info</returns>
		public static CliArgsInfo AsRequired(this CliArgsInfo info)
        {
			info.Optional = false;
			return info;
        }

		public static CliArgsInfo AsOptional(this CliArgsInfo info)
		{
			info.Optional = true;
			return info;
		}

		public static CliArgsInfo WithShortName(this CliArgsInfo info, string shortName)
		{
			info.ShortName = shortName;
			return info;
		}

		public static CliArgsInfo WithDescription(this CliArgsInfo info, string description)
		{
			info.Description = description;
			return info;
		}

		public static CliArgsInfo WithUsage(this CliArgsInfo info, string usage)
		{
			info.Usage = usage;
			return info;
		}
	}
}

