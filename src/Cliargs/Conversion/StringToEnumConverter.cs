using System;
namespace Cliargs
{
    public class StringToEnumConverter : ValueTypeConverter
	{
        public override object? GetConverted(Type type, string value)
        {
			if (!type.IsEnum)
				throw new CliArgsException("This converter is only for enums");

			if (Enum.TryParse(type, value, out var convertedValue))
				return convertedValue;

			return null;
		}
    }
}

