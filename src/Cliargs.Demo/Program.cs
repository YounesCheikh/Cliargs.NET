// See https://aka.ms/new-console-template for more information
using Cliargs;
using Cliargs.Extensions;
using Cliargs.Validation;

Console.WriteLine("Hello, World!");

var cliArgsConfig = CLIArguments.New()
    .WithArgument<int>(CliArgumentContext<int>
    .New(
        ArgumentInfo
        .New("category")
        .WithShortName("c")
        .WithDescription("Just the category, 1, 2, 3")
        .WithUsage("--cateogyr=1 or -c=3")).WithRule<int>(new RangeValidationRule<int>(new[] { 1, 2, 3 })));
    ;

