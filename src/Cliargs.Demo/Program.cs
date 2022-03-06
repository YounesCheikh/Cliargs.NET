using System.Globalization;
using Cliargs;
using Cliargs.Demo;

MyArgs myArgs;
try {
    AppCliArgs.Initialize<CliArgsSetup>(new CustomFormat());
    myArgs = AppCliArgs.GetArgsParsed<MyArgs>();
}
catch(CliArgsException exception){
    Console.WriteLine($"Error: {exception.Message}");
    return;
} 

if(AppCliArgs.IsHelpRequested())
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

    return;
}

// Reaching this position, means all required argumnets are set
var name = myArgs.Name; // OR // AppCliArgs.GetArgValue<string>("Name");
uint? age = null;
bool highlight = myArgs.Highlight; // Or // AppCliArgs.IsSet("Highlight");

string output = $"Hello {name}, we don't know your age!";

if(AppCliArgs.IsSet("Age")) {
    age = AppCliArgs.GetArgValue<uint>("Age");
    output = $"Hello {name}, You are {age} years old!";
}

if(highlight) {
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = ConsoleColor.DarkRed;
}
Console.WriteLine(output);
if(highlight)
    Console.ResetColor();

