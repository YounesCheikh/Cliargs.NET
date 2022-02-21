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
                .ValidatedWithRules(
                     GreaterThanOrEqualsRule<uint>.Value(1),
                     LessThanOrEqualsRule<uint>.Value(12)
                );

             var username = CliArg.New<string>("username")
                .AsOptional()
                .WithLongName("user")
                .WithShortName("u")
                .WithDescription("The username starting with J and ending in N")
                .WithUsage("--user JOHN")
                .ValidatedWithRule(ConditionalRule<string>.WithCondition(
                    s=> s.ToUpper().StartsWith("J") && s.ToUpper().EndsWith("N"))
                );

            container.Register(monthArgument);
            container.Register(yearArgument);
            container.Register(username);
            container.Register(
                CliArg.New("english-display")
                .AsOptional()
                .WithShortName("ed")
                .WithDescription("Display the month in English")
                );
        }
    }
}

