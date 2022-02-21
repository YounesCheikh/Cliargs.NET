using System;
using Cliargs.Rules;
namespace Cliargs.Demo
{
    public class CliArgsSetup : ICliArgsSetup
    {
        public void Configure(ICliArgsContainer container)
        {
            var yearArgument = CliArg.New<uint>("year")
                .AsRequired()
                .WithShortName("y")
                .WithDescription("The year")
                .WithUsage("--year 2020")
                .ValidatedWithRule(RangeValidationRule<uint>.FromRange(new uint[] {2019, 2020, 2021, 2022}))
                ;

            var monthArgument = CliArg.New<uint>("month")
                .AsRequired()
                .WithShortName("m")
                .WithDescription("The month from 1 to 12")
                .WithUsage("--month 10 | -m 10")
                .ValidatedWithRules(new List<ICliArgsValidationRule<uint>>() {
                      new GreaterThanRule<uint>(0),
                        new LessThanRule<uint>(13)
                });

            container.Register(monthArgument);
            container.Register(yearArgument);
            container.Register(
                CliArg.New("english-display")
                .AsOptional()
                .WithShortName("ed")
                .WithDescription("Display the month in English")
                );
        }
    }
}

