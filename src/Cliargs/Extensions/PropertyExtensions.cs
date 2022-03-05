using System.Reflection;
using Cliargs;
namespace Cliargs.Extensions
{
    public static class PropertyExtensions
    {
        internal static bool HasAttribute<TAttr> (this PropertyInfo propertyInfo ) where TAttr: Attribute
        {
            return propertyInfo.GetCustomAttribute<TAttr>(true) != null;
        }

        internal static bool HasArgNameAttribute (this PropertyInfo propertyInfo )
        {
            return propertyInfo.HasAttribute<CliArgNameAttribute>();
        }

        internal static TAttr? GetAttribute<TAttr> (this PropertyInfo propertyInfo ) where TAttr: Attribute
        {
            return propertyInfo.GetCustomAttribute<TAttr>(true);
        }

        internal static CliArgNameAttribute? GetArgNameAttribute (this PropertyInfo propertyInfo )
        {
            return propertyInfo.GetAttribute<CliArgNameAttribute>();
        }

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