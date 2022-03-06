namespace Cliargs.Demo
{
    public class MyArgs
    {
        [CliArgName("Name")]
        public string? Name { get; set; }

        [CliArgName("Age")]
        public uint? Age {get; set;}

        [CliArgName("Highlight")]
        public bool Highlight { get; set; }
    }
}