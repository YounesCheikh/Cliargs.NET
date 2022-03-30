namespace Cliargs
{
    internal interface ICliargsNamesParser
    {
        /// <summary>
        /// Parse arguments into object properties
        /// </summary>
        /// <typeparam name="T">Object with args properties</typeparam>
        /// <returns>the instance from type T</returns>
        T Parse<T>() where T: new();
    }
}