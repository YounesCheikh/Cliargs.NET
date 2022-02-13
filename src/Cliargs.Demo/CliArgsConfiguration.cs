using System;
using Cliargs.Extensions;
using Cliargs.Validation;
namespace Cliargs.Demo
{
    public class CliArgsConfiguration : IArgsConfiguration
    {
        public void Configure(CLIArguments arguments)
        {
            var yearArgInfo = ArgumentInfo.New("year")
                .WithDescription("The year")
                .WithShortName("y")
                .WithUsage("--year=2022");
            var yearArg = CliArgumentContext<int>.New(yearArgInfo).WithRule<int>(new RangeValidationRule<int>(new int [] { 1, 2, 3 }));

            arguments.AddCliArgument<int>(yearArg);
        }
    }
}

