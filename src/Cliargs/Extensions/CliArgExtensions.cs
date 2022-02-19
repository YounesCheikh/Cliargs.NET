using System;
namespace Cliargs
{
	public static class CliArgExtensions
	{
		public static CliArg<T> AsRequired<T>(this CliArg<T> arg)
		{
			arg.Info.Optional = false;
			return arg;
		}

		public static CliArg<T> AsOptional<T>(this CliArg<T> arg)
		{
			arg.Info.Optional = true;
			return arg;
		}

		public static CliArg<T> WithShortName<T>(this CliArg<T> arg, string shortName)
		{
			arg.Info.ShortName = shortName;
			return arg;
		}

		public static CliArg<T> WithDescription<T>(this CliArg<T> arg, string description)
		{
			arg.Info.Description = description;
			return arg;
		}

		public static CliArg<T> WithUsage<T>(this CliArg<T> arg, string usage)
		{
			arg.Info.Usage = usage;
			return arg;
		}

		public static CliArg<T> ValidatedWithRule<T>(this CliArg<T> arg, ICliArgsValidationRule<T> rule)
		{
			arg.ValidationRules.Add(rule);
			return arg;
		}

		public static CliArg<T> ValidatedWithRules<T>(this CliArg<T> arg, IEnumerable<ICliArgsValidationRule<T>> rules)
		{
			arg.ValidationRules.AddRange(rules);
			return arg;
		}

		public static CliArg<T> ValidatedWithRules<T>(this CliArg<T> arg, params ICliArgsValidationRule<T>[] rules)
		{
			arg.ValidationRules.AddRange(rules);
			return arg;
		}
	}
}

