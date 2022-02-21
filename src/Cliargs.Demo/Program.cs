using System.Globalization;
using Cliargs;
using Cliargs.Demo;

try {
    AppCliArgs.Initialize<CliArgsSetup>(new CustomFormat());
}
catch(CliArgsException exception){
    Console.WriteLine($"Error: {exception.Message}");
    return;
} 

if(AppCliArgs.IsSet(CliArgsOptions.HelpArg.Name))
{
    Console.WriteLine(AppCliArgs.GetHelpString());
    return;
}

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
    if (AppCliArgs.IsSet("english-display"))
    {
        string fullMonthName = new DateTime((int)year, (int)month, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
        Console.WriteLine($"Date: {fullMonthName} {year:D4}");
    }
    else
    Console.WriteLine($"Date: {month:D2}/{year:D4}");
}
