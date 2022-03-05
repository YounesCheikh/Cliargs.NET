using System.Reflection;
using Cliargs.Extensions;

namespace Cliargs
{
    public class CliargsNamesParser : ICliargsNamesParser
    {
        ICliArgsContainer _container;
        public CliargsNamesParser(ICliArgsContainer container)
        {
            _container = container;
        }

        public T Parse<T>() where T : new()
        {
            T obj = new T();

            var argsProperties = typeof(T).GetProperties(BindingFlags.Public);
            foreach(var argProperty in argsProperties) {
                CliArgNameAttribute argNameAttr;
                if(!argProperty.TryGetArgNameAttribute(out argNameAttr)) {
                    continue;
                }

                string argName = string.IsNullOrWhiteSpace(argNameAttr.Name)
                    ? argProperty.Name
                    : argNameAttr.Name;

                var registeredArg = _container.GetCliArgByName(argName);
                if(registeredArg == null)
                    throw new CliArgsException($"No CLI argument registered with name {argName}");

                if(!registeredArg.IsSet)
                    continue;

                var argValue = _container.GetValue(argName);
                argProperty.SetValue(obj, argValue);

            }
            return obj;
        }
    }
}