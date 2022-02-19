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

		ValueTypeConverter()
		{
		}

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

		public static ValueTypeConverter Default => _default;
	}
}

