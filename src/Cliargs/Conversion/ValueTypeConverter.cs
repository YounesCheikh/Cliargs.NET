using System;
namespace Cliargs
{
	/// <summary>
    /// This class is responsible of coverting the given string value to a typed object.
    /// </summary>
	public class ValueTypeConverter
	{
		private static readonly ValueTypeConverter _default;
		private static readonly object syncObj = new();

		static ValueTypeConverter()
        {
            if (_default == null)
                lock (syncObj)
                {
                    if (_default == null)
                        _default = new ValueTypeConverter();
                }
        }

        ValueTypeConverter()
		{
		}

		/// <summary>
		/// Convert a given string to a typed object
		/// </summary>
		/// <typeparam name="T">The target object type</typeparam>
		/// <param name="inputValue">The string value</param>
		/// <returns>The created instance</returns>
		/// <exception cref="CliArgsException">If failed to parse the string into an enum</exception>
		/// <exception cref="CliArgsException">If failed to change the type using Covert.ChangeType method</exception>
		public virtual T ConvertFromString<T>(string inputValue) 
        {
			try
			{
				if (typeof(T).IsEnum)
				{
					if (Enum.GetNames(typeof(T)).Select(e => e.ToLower()).Contains(inputValue.ToLower()))
					{
						var obj = Enum.Parse(typeof(T), inputValue, true);
						if (obj is T)
							return (T)obj;
					}
					throw new CliArgsException($"Unable to covert value to enum type ({typeof(T)})");
				}
				var typedObj = Convert.ChangeType(inputValue, typeof(T));
				if (typedObj is T)
					return (T)typedObj;
				throw new CliArgsException($"Failed to change type from string to ({typeof(T)}) of value {inputValue}");
			}
			catch(Exception exception)
            {
				throw new CliArgsException($"Unable to covert value ({inputValue}) to type ({typeof(T)})", exception);
            }
		}

		/// <summary>
        /// Default Converter native instance 
        /// </summary>
		public static ValueTypeConverter Default => _default;
	}
}

