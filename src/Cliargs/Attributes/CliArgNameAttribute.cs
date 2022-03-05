namespace Cliargs
{
    public class CliArgNameAttribute: Attribute
    {
        /// <summary>
        ///  The CLI argument name
        /// </summary>
        /// <value>The argument name if set otherwise null</value>
        public string? Name { get; } = default;

        /// <summary>
        /// Set the property argument name
        /// </summary>
        /// <param name="name">The argument name, 
        /// if not set, the property name is set as argument name.</param>
        public CliArgNameAttribute(string? name = default)
        {
            this.Name = name;
        }
    }
}