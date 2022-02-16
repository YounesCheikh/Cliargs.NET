using System;
namespace Cliargs.Conversion
{
	public class ValueTypeConverter
	{
		private static readonly ValueTypeConverter _default;
		private static readonly object syncObj = new();

		static ValueTypeConverter() {
			if (_default != null)
				return;
			lock(syncObj)
            {
				if (_default != null)
					return;
				_default = new ValueTypeConverter();
            }
		}

		public ValueTypeConverter()
		{
		}

		public virtual T ConvertFromString<T>(string inputValue)
        {
			return (T)Convert.ChangeType(inputValue, typeof(T));
		}

		public static ValueTypeConverter Default => _default;
	}
}

