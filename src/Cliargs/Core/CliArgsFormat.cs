using System;
namespace Cliargs
{
    /// <summary>
    /// The command line argument format
    /// </summary>
	public class CliArgsFormat
	{
		private static CliArgsFormat _default;
		private static readonly object syncObj = new object();
		static CliArgsFormat()
        {
            if (_default == null)
                lock (syncObj)
                {
                    if (_default == null)
                        _default = new CliArgsFormat();
                }
        }

        private CliArgsFormat()
        {

        }

        /// <summary>
        /// Create new instance
        /// </summary>
        /// <param name="assignationChar">The value assignation character</param>
		public CliArgsFormat(char assignationChar)
		{
			this.AssignationChar = assignationChar;
		}

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="assignationChar">The value assignation character</param>
        /// <param name="namePrefix">The argument long name prefix</param>
        /// <param name="shortNamePrefix">The argument short name prefix</param>
		public CliArgsFormat(char assignationChar, string longNamePrefix, string shortNamePrefix): this(assignationChar)
		{
			LongNamePrefix = longNamePrefix;
			ShortNamePrefix = shortNamePrefix;
		}

		/// <summary>
        /// The assignation character,
        /// The symbol used to assign value to an argument.
        /// Default character is space ' '
        /// <code>--key value</code>
        /// </summary>
		public virtual char AssignationChar { get; protected set; } = ' ';

		/// <summary>
        /// Argument name prefix
        /// The symbol preceeding the argument name
        /// Default : '--'
        /// <code>--key=value</code>
        /// </summary>
		public virtual string LongNamePrefix { get; protected set; } = "--";

		/// <summary>
        /// The short name prefix
        /// The symbol preceeding the argument short name
        /// Defualt: '-'
        /// <code>-K=value</code>
        /// </summary>
		public virtual string ShortNamePrefix { get; protected set; } = "-";

		/// <summary>
        /// Default Commande Line arguments format
        /// </summary>
		public static CliArgsFormat Default => _default;
	}
}

