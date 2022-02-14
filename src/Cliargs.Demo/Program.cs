// See https://aka.ms/new-console-template for more information
using Cliargs;
using Cliargs.Extensions;
using Cliargs.Validation;
using Cliargs.Demo;

Console.WriteLine("Hello, World!");

var cliArgs = CLIArguments.New<CliArgsConfiguration>();
cliArgs.Build();
var validationResults = cliArgs.Validate();

if(!validationResults.All(e=> e.IsValid))
{
    var firstOccurence = validationResults.First(e => !e.IsValid);
    Console.WriteLine($"Error in Value : {firstOccurence.ArgumentInputValue}");
    Console.WriteLine($"Message : {firstOccurence.Rule.GetValidationError()}");
    if(!string.IsNullOrWhiteSpace(firstOccurence.Info.Usage))
        Console.WriteLine($"Usage : {firstOccurence.Info.Usage}");
}

int year = cliArgs.GetArgValue<int>("year");
Console.WriteLine(year);




