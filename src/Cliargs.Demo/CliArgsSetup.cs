using System;
using Cliargs.Rules;
namespace Cliargs.Demo
{
    public class CliArgsSetup : ICliArgsSetup
    {
        public void Configure(ICliArgsContainer container)
        {
            // The user real name
            container.Register(
                CliArg.New<string>("Name")
                .AsRequired()
                .WithLongName("name")
                .WithShortName("n")
                .WithDescription("The user real name")
                .WithUsage($"-n|--name \"John Doe\"")
            );

            // The user real age
            container.Register(
                CliArg.New<uint>("Age")
                .AsOptional()
                .WithLongName("age")
                .WithShortName("a")
                .WithDescription("The user age in years")
                .WithUsage("-a|--age 28")
            );

            // Option to highlight the output 
            container.Register(
                CliArg.New("Highlight")
                .AsOptional()
                .WithLongName("highlight")
                .WithShortName("hl")
                .WithDescription("Highlight the output in color")
                .WithUsage("-hl|--highlight")
            );
        }
    }
}

