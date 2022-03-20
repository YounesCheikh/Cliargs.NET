using System;
using System.Reflection;
using Cliargs;
namespace Cliargs
{
    public static class PropertyExtensions
    {
        internal static bool TryGetAttribute<TAttr> (this PropertyInfo propertyInfo, out TAttr attr) where TAttr: Attribute
        {
            var attribute = propertyInfo.GetCustomAttribute<TAttr>(true);
            if(attribute == null) {
#pragma warning disable CS8625
                attr = default;
#pragma warning restore CS8625
                return false;
            }

            attr = attribute;
            return true;
        }

        internal static bool TryGetArgNameAttribute (this PropertyInfo propertyInfo, out CliArgNameAttribute attr)
        {
            return propertyInfo.TryGetAttribute<CliArgNameAttribute>(out attr);
        }
    }
}