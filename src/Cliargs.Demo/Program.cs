// See https://aka.ms/new-console-template for more information
using Cliargs;
using Cliargs.Demo;

Console.WriteLine("Hello, World!");

var cliArgs = AppCliArgs.Use<CliArgsSetup>();
if(cliArgs.HasValidationErrors)
{
    var validationResults = cliArgs.GetValidationResults();
    foreach (var result in validationResults)
    {
        Console.WriteLine(result);
    }
}
else
{
    var year = cliArgs.GetArgValue<uint>("year");
    Console.WriteLine(year);
}




