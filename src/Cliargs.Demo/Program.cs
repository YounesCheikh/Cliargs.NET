using Cliargs;
using Cliargs.Demo;

Console.WriteLine("Hello, World!");

var cliArgs = AppCliArgs.Use<CliArgsSetup>(new CustomFormat());
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
    var month = cliArgs.GetArgValue<uint>("month");
    var year = cliArgs.GetArgValue<uint>("year");
    Console.WriteLine($"Date: {month:D2}/{year:D4}");
}
