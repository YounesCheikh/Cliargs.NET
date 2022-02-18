using System;
namespace Cliargs
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

		public virtual T? ConvertFromString<T>(string inputValue)
        {
			if (typeof(T).IsEnum)
			{
				try
				{
					T res = (T)Enum.Parse(typeof(T), inputValue);
					if (!Enum.IsDefined(typeof(T), res)) return default;
					return res;
				}
				catch
				{
					return default;
				}
			}
			return (T)Convert.ChangeType(inputValue, typeof(T));
		}

		public static ValueTypeConverter Default => _default;
	}
}

