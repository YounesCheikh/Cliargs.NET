// See https://aka.ms/new-console-template for more information
using Cliargs;
using Cliargs.Extensions;
using Cliargs.Validation;
using Cliargs.Demo;
Console.WriteLine("Hello, World!");

var cliArgs = CLIArguments.New<CliArgsConfiguration>();
cliArgs.Validate();





