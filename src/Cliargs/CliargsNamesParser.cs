using System.Reflection;
namespace Cliargs
{
    class CliargsNamesParser : ICliargsNamesParser
    {
        ICliArgsContainer _container;
        public CliargsNamesParser(ICliArgsContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Create a new instance of the object hosting 
        /// the arguments data, and Parse the arguments into it. 
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <returns>The created instance</returns>
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
                        // Another property not supposed to represent an argument.
                        continue;
                    }

                    // If the name is not set on the property 
                    // Use the property name
                    string argName = string.IsNullOrWhiteSpace(argNameAttr.Name)
                        ? argProperty.Name
                        : argNameAttr.Name;

                    var registeredArg = _container.GetCliArgByName(argName);

                    // Throws an exception if the container doesn't contain 
                    // any argument having the name as set.
                    if (registeredArg == null)
                        throw new CliArgsException($"No CLI argument registered with name {argName}");

                    // If argument is not set, do nothing!
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