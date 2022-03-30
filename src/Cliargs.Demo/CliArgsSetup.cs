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
                CliArg.New<string>(nameof(MyArgs.Name))
                .AsRequired()
                .WithLongName("name")
                .WithShortName("n")
                .WithDescription("The user real name")
                .WithUsage($"-n|--name \"John Doe\"")
            );

            // The user real age
            // Long and short names are generated
            container.Register(
                CliArg.New<uint>(nameof(MyArgs.Age))
                .AsOptional()
                //.WithLongName("age")
                //.WithShortName("a")
                .WithDescription("The user age in years")
                .WithUsage("-a|--age 28")
            );

            container.Register(
                CliArg.New<uint>(nameof(MyArgs.PaddingLines))
                .AsOptional((uint)1)
                .WithLongName("padding")
                .WithShortName("p")
                .WithDescription("Padding Lines on top and bottom")
                .WithUsage("-p|--padding 2")
            );

            // Option to highlight the output 
            container.Register(
                CliArg.New(nameof(MyArgs.Highlight))
                .AsOptional()
                .WithLongName("highlight")
                .WithShortName("hl")
                .WithDescription("Highlight the output in color")
                .WithUsage("-hl|--highlight")
            );
        }
    }
}

