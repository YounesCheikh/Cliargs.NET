using System;
namespace Cliargs
{
	public interface IValueTypeConverter
	{
		object? GetConverted(Type type, string value);
	}
}

