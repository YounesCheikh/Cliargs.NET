using System;
namespace Cliargs
{
    public class StringToEnumConverter : ValueTypeConverter
	{
        public override object? GetConverted(Type type, string value)
        {
			object? parsedValue = null;
			if (!type.IsEnum)
				throw new CliArgsException("This converter is only for enums");
#if NETCOREAPP3_0_OR_GREATER
			if (Enum.TryParse(type, value, out var convertedValue))
				return convertedValue;
#elif NET45_OR_GREATER
			try {
			parsedValue = Enum.Parse(type, value);
			}
			catch{
				return null;
			}
#endif

			return parsedValue;
		}
    }
}

