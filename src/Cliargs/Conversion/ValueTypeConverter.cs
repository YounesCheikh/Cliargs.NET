using System;
namespace Cliargs.Conversion
{
	public class ValueTypeConverter
	{
		public ValueTypeConverter()
		{
		}

		public virtual T ConvertFromString<T>(string inputValue)
        {
			return (T)Convert.ChangeType(inputValue, typeof(T));
		}
	}
}

