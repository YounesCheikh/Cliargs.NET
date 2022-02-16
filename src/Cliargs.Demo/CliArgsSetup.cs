using System;
namespace Cliargs.Demo
{
    public class CliArgsSetup : ICliArgsSetup
    {
        public void Configure(ICliArgsContainer container)
        {
            //var yearArgInfo = ArgumentInfo.New("year")
            //    .WithDescription("The year")
            //    .WithShortName("y")
            //    .WithUsage("--year=2022");
            //var yearArg = CliArgumentContext<int>.New(yearArgInfo).WithRule<int>(new RangeValidationRule<int>(new int [] { 1, 2, 3 }));

            //arguments.AddCliArgument<int>(yearArg);
        }
    }
}

