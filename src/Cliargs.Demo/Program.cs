using Cliargs;
using Cliargs.Demo;

Console.WriteLine("Hello, World!");

AppCliArgs.Initialize<CliArgsSetup>(new CustomFormat());

if(AppCliArgs.HasValidationErrors)
{
    var validationResults = AppCliArgs.GetValidationResults();
    foreach (var result in validationResults)
    {
        Console.WriteLine(result.GetReport());
    }
}
else
{
    var month = AppCliArgs.GetArgValue<uint>("month");
    var year = AppCliArgs.GetArgValue<uint>("year");
    Console.WriteLine($"Date: {month:D2}/{year:D4}");
}
