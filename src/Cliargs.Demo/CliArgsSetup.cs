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

            var monthArgument = CliArg<uint>.New("month")
                .AsRequired()
                .WithShortName("m")
                .WithDescription("The month from 1 to 12")
                .WithUsage("--month 10 | -m 10")
                .ValidatedWithRules(new List<ICliArgsValidationRule<uint>>() {
                      new GreaterThanRule<uint>(1),
                        new LessThanRule<uint>(12)
                });

            container.Register(monthArgument);
            container.Register(yearArgument);
        }
    }
}

