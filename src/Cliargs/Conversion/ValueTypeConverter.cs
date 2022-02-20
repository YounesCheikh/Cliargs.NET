using System;

namespace Cliargs
{
	/// <summary>
    /// This class is responsible of coverting the given string value to a typed object.
    /// </summary>
	public class ValueTypeConverter: IValueTypeConverter
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

        protected ValueTypeConverter()
		{
		}

        public virtual object? GetConverted(Type type, string value)
        {
			try
			{
				var typedObj = Convert.ChangeType(value, type);
				return typedObj;
			}
			catch
            {
				return null;
            }
		}

        /// <summary>
        /// Default Converter native instance 
        /// </summary>
        public static ValueTypeConverter Default => _default;
	}
}

