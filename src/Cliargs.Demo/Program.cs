using System.Globalization;
using Cliargs;
using Cliargs.Demo;

Console.WriteLine("Hello, World!");

AppCliArgs.Initialize<CliArgsSetup>(new CustomFormat());

if(AppCliArgs.IsSet("help"))
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
    if (AppCliArgs.IsSet("display-format"))
    {
        string fullMonthName = new DateTime((int)year, (int)month, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
        Console.WriteLine($"Date: {fullMonthName} {year:D4}");
    }
    else
    Console.WriteLine($"Date: {month:D2}/{year:D4}");
}
