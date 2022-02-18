using System;

namespace Cliargs.Demo
{
    public class CliArgsSetup : ICliArgsSetup
    {
        public void Configure(ICliArgsContainer container)
        {
            var yearArgument = CliArg<uint>.New("year")
                .AsRequired()
                .WithShortName("y")
                .WithDescription("The year")
                .WithUsage("--year 2020")
                .ValidatedWithRule(RangeValidationRule<uint>.FromRange(new uint[] {2019, 2020, 2021, 2022}))
                ;

            container.Register(yearArgument);
        }
    }
}

