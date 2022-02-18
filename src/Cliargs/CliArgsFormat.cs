using System;
namespace Cliargs
{
	public class CliArgsFormat
	{
		private static CliArgsFormat _default;
		private static readonly object syncObj = new object();
		static CliArgsFormat()
        {
			if (_default != null)
				return;

            lock (syncObj)
            {
				if (_default != null)
					return;

				_default = new CliArgsFormat();
            }
        }

		public CliArgsFormat()
        {

        }

		public CliArgsFormat(string assignationChar)
		{
			this.AssignationChar = assignationChar;
		}

		public CliArgsFormat(string assignationChar, string namePrefix, string shortNamePrefix): this(assignationChar)
		{
			NamePrefix = namePrefix;
			ShortNamePrefix = shortNamePrefix;
		}

		/// <summary>
        /// The assignation character,
        /// The symbol used to assign value to an argument.
        /// Default character is space ' '
        /// <code>--key value</code>
        /// </summary>
		public virtual string AssignationChar { get; protected set; } = " ";

		/// <summary>
        /// Argument name prefix
        /// The symbol preceeding the argument name
        /// Default : '--'
        /// <code>--key=value</code>
        /// </summary>
		public virtual string NamePrefix { get; protected set; } = "--";

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

