using System.Reflection;
using Cliargs.Extensions;

namespace Cliargs
{
    class CliargsNamesParser : ICliargsNamesParser
    {
        ICliArgsContainer _container;
        public CliargsNamesParser(ICliArgsContainer container)
        {
            _container = container;
        }

        public T Parse<T>() where T : new()
        {
            try
            {
                T obj = new T();

                var argsProperties = typeof(T).GetProperties();
                foreach (var argProperty in argsProperties)
                {
                    CliArgNameAttribute argNameAttr;
                    if (!argProperty.TryGetArgNameAttribute(out argNameAttr))
                    {
                        continue;
                    }

                    string argName = string.IsNullOrWhiteSpace(argNameAttr.Name)
                        ? argProperty.Name
                        : argNameAttr.Name;

                    var registeredArg = _container.GetCliArgByName(argName);
                    if (registeredArg == null)
                        throw new CliArgsException($"No CLI argument registered with name {argName}");

                    if (!registeredArg.IsSet)
                        continue;

                    var argValue = _container.GetValue(argName);
                    argProperty.SetValue(obj, argValue);

                }
                return obj;
            }
            catch(ArgumentException exception)
            {
                throw new CliArgsException($"Failed to parse to type {typeof(T)}, ensure all properties in this class have the same type of args as registered.", exception);
            }
            catch(Exception exception)
            {
                throw new CliArgsException($"Failed to parse to type {typeof(T)}", exception);
            }
        }
    }
}