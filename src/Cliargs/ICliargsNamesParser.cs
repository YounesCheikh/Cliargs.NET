namespace Cliargs
{
    public interface ICliargsNamesParser
    {
        public T Parse<T>() where T: new();
    }
}