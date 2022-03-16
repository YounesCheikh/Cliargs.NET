using System;
using System.Collections.Generic;

namespace Cliargs
{
	public static class CliArgExtensions
	{
		/// <summary>
        /// Mark a Command Line Interface argument is required.
        /// </summary>
        /// <typeparam name="T">The argument type</typeparam>
        /// <param name="arg">The argument</param>
        /// <returns>The argument marked as required</returns>
		public static CliArg<T> AsRequired<T>(this CliArg<T> arg)
		{
			arg.Info.Optional = false;
			return arg;
		}

		/// <summary>
		/// Mark a Command Line Interface argument is optional.
		/// </summary>
		/// <typeparam name="T">The argument type</typeparam>
		/// <param name="arg">The argument</param>
		/// <returns>The argument marked as optional</returns>
		public static CliArg<T> AsOptional<T>(this CliArg<T> arg, T? defaultValue = default)
		{
			arg.Info.Optional = true;
			arg.DefaultValue = defaultValue;
			return arg;
		}

		/// <summary>
		/// Mark a Command Line Interface argument is optional.
		/// </summary>
		/// <param name="arg">The argument</param>
		/// <returns>The argument marked as optional</returns>
		public static CliArg AsOptional(this CliArg arg)
		{
			arg.Info.Optional = true;
			return arg;
		}


		public static CliArg<T> NoRequiredValue<T>(this CliArg<T> arg)
		{
			arg.Info.RequiresValue = false;
			return arg;
		}

		/// <summary>
		/// Set a short name for the Command Line Interface argument.
		/// </summary>
		/// <typeparam name="T">The argument type</typeparam>
		/// <param name="shortName">The argument shortname</param>
		/// <returns>The argument updated</returns>
		public static CliArg<T> WithShortName<T>(this CliArg<T> arg, string shortName)
		{
			arg.Info.ShortName = shortName;
			return arg;
		}

		/// <summary>
		/// Sets a long name for the CLI Argument
		/// </summary>
		/// <param name="longName">The long name</param>
		/// <typeparam name="T">The argument type</typeparam>
		/// <returns>The argument updated</returns>
		public static CliArg<T> WithLongName<T>(this CliArg<T> arg, string longName)
		{
			arg.Info.LongName = longName;
			return arg;
		}

		/// <summary>
		/// Set a short name for the Command Line Interface argument.
		/// </summary>
		/// <param name="shortName">The argument shortname</param>
		/// <returns>The argument updated</returns>
		public static CliArg WithShortName(this CliArg arg, string shortName)
		{
			arg.Info.ShortName = shortName;
			return arg;
		}

		/// <summary>
		/// Sets a long name for the command line interface argument
		/// </summary>
		/// <param name="longName">The argument long name</param>
		/// <returns>The argument updated</returns>
		public static CliArg WithLongName(this CliArg arg, string longName)
		{
			arg.Info.LongName = longName;
			return arg;
		}

		/// <summary>
		/// Set a description for the Command Line Interface argument.
		/// </summary>
		/// <typeparam name="T">The argument type</typeparam>
		/// <param name="arg">The argument</param>
		/// <param name="description">The description</param>
		/// <returns>Updated argument </returns>
		public static CliArg<T> WithDescription<T>(this CliArg<T> arg, string description)
		{
			arg.Info.Description = description;
			return arg;
		}

		/// <summary>
		/// Set a description for the Command Line Interface argument.
		/// </summary>
		/// <param name="arg">The argument</param>
		/// <param name="description">The description</param>
		/// <returns>Updated argument </returns>
		public static CliArg WithDescription(this CliArg arg, string description)
		{
			arg.Info.Description = description;
			return arg;
		}

		/// <summary>
		/// Set a usage sample example for a given argument
		/// </summary>
		/// <typeparam name="T">The argument type</typeparam>
		/// <param name="arg">The argument</param>
		/// <param name="usage">The argument usage example</param>
		/// <returns>Updated argument</returns>
		public static CliArg<T> WithUsage<T>(this CliArg<T> arg, string usage)
		{
			arg.Info.Usage = usage;
			return arg;
		}

		/// <summary>
		/// Set a usage sample example for a given argument
		/// </summary>
		/// <param name="arg">The argument</param>
		/// <param name="usage">The argument usage example</param>
		/// <returns>Updated argument</returns>
		public static CliArg WithUsage(this CliArg arg, string usage)
		{
			arg.Info.Usage = usage;
			return arg;
		}

		/// <summary>
		/// Add a rule to apply for argument value validation
		/// </summary>
		/// <param name="rule">The validation rule</param>
		public static CliArg<T> ValidatedWithRule<T>(this CliArg<T> arg, ICliArgsValidationRule<T> rule)
		{
			arg.ValidationRules.Add(rule);
			return arg;
		}

		/// <summary>
        /// Add a set of rules to validate the argument value
        /// </summary>
		public static CliArg<T> ValidatedWithRules<T>(this CliArg<T> arg, IEnumerable<ICliArgsValidationRule<T>> rules)
		{
			arg.ValidationRules.AddRange(rules);
			return arg;
		}

		/// <summary>
		/// Add a set of rules to validate the argument value 
		/// </summary>
		public static CliArg<T> ValidatedWithRules<T>(this CliArg<T> arg, params ICliArgsValidationRule<T>[] rules)
		{
			arg.ValidationRules.AddRange(rules);
			return arg;
		}

		/// <summary>
		/// Sets the argument vale converter
		/// </summary>
		/// <param name="converter">The converter</param>
		/// <typeparam name="T">The type to convert</typeparam>
		/// <returns>The argument updated</returns>
		public static CliArg<T> ValueConvertedWith<T>(this CliArg<T> arg, IValueTypeConverter converter)
		{
			arg.Converter = converter;
			return arg;
		}
	}
}

