## Command Line Interface Arguments parser for C#

[![.NET](https://github.com/YounesCheikh/Cliargs.NET/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/YounesCheikh/Cliargs.NET/actions/workflows/dotnet.yml)
[![NuGet Badge](https://buildstats.info/nuget/Cliargs.NET)](https://www.nuget.org/packages/Cliargs.NET/)

[![Build history](https://buildstats.info/github/chart/younescheikh/Cliargs.NET)](https://buildstats.info/github/chart/younescheikh/Cliargs.NET)

![image](https://raw.githubusercontent.com/YounesCheikh/Cliargs.NET/main/Cliargs.png)


Cliargs.NET is a .NET library helps you to parse and use the Command Line Interface arguments in easy way. 

The main goal of Cliargs.NET is to help C# developers reduce their programming time without dealing with all validations and casting of the user input. 

Cliargs.NET makes all for you, all you have to do is write your Setup configuration in order to configure the Arguments container, then, from key and values parsing, to validation is automatically done on app startup. 

## Quick comparison 

In this example, you see the difference between managing the command line arguments by yourself, or by Cliargs.NET, for an application with two arguments:

| Argument &nbsp; &nbsp; &nbsp; &nbsp; | type | key | short key | Optional |
| :---: | :---: | :---: | :---: | :---: |
| User Name | string | --name | -n | no |
| User age | uint | --age | -a | yes |

The objective is to display the following message in a console app: 
> Dear {user name}, you're {user age} years old!


### Example of old school way: 😔

```csharp
var userInputArgs = Environment.GetCommandLineArgs().Skip(1).ToArray();
if(userInputArgs.Length == 0)
{
    Console.WriteLine("Missing mandatory arguments: --name");
    return;
}

string name = string.Empty;
uint? age = null;
var currentKey = string.Empty;
foreach(var arg in userInputArgs)
{
    if(currentKey == "--name" || currentKey == "-n")
    {
        name = arg;
        currentKey = string.Empty;
        continue;
    }

    if (currentKey == "--age" || currentKey == "-a")
    {
        age = Convert.ToUInt32(arg);
        currentKey = string.Empty;
        continue;
    }

    if (arg == "--name" || arg == "-n")
    {
        currentKey = arg;
        continue;
    }

    if (arg == "--age" || arg == "-a")
    {
        currentKey = arg;
        continue;
    }

    Console.WriteLine("Error: Unkown argument {0}", arg);
    return;
}

if(string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("Wrong value for name");
    return;
}

if(age.HasValue)
{
    Console.WriteLine($"Dear {name}, you're {age.Value} years old.");
}
else
{
    Console.WriteLine($"Dear {name}, we don't know your age!");
}
```

### New way with Cliargs.NET 🤩

Create your Setup class and implement the `Configure` method to create your app arguments: 

```csharp
public class CliArgsSetup : ICliArgsSetup
{
    public void Configure(ICliArgsContainer container)
    {
        var nameArg = CliArg.New<string>("name")
            .AsRequired()
            .WithShortName("n");

        var ageArg = CliArg.New<uint>("age")
            .AsOptional()
            .WithShortName("a");

        container.Register(nameArg);
        container.Register(ageArg);
    }
}
```

Initialize the AppCliArgs instance by calling `Initialize` method at the begining of your app main method: 

```csharp 
AppCliArgs.Initialize<CliArgsSetup>(new CustomFormat());
```

The finally start using the arguments values

```csharp 
var name = AppCliArgs.GetArgValue<string>("name");
if (AppCliArgs.IsSet("age"))
{
    var age = AppCliArgs.GetArgValue<uint>("age");
    Console.WriteLine($"Dear {name}, you're {age} years old.");
}
else
{
    Console.WriteLine($"Dear {name}, we don't know your age!");
}
```

## TODO 
> More documentation is coming... 
