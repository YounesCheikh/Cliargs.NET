# Command Line Interface Arguments parser for C#

[![.NET](https://github.com/YounesCheikh/Cliargs.NET/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/YounesCheikh/Cliargs.NET/actions/workflows/dotnet.yml) 
[![NuGet Badge](https://buildstats.info/nuget/Cliargs.NET)](https://www.nuget.org/packages/Cliargs.NET/)  
[![License](https://img.shields.io/badge/License-CC%20BY--NC--SA%204.0-yellowgreen)](https://creativecommons.org/licenses/by-nc-sa/4.0/) 


| ![image](https://raw.githubusercontent.com/YounesCheikh/Cliargs.NET/main/Cliargs.png) | [![Build history](https://buildstats.info/github/chart/younescheikh/Cliargs.NET)](https://buildstats.info/github/chart/younescheikh/Cliargs.NET) | 
| :---: | :---: | 

Cliargs.NET is a .NET library helps you to parse and use the Command Line Interface arguments in easy way. 

The main goal of Cliargs.NET is to help C# developers reduce their programming time without dealing with all validations and casting of the user input. 

Cliargs.NET makes all for you, all you have to do is write your Setup configuration in order to configure the Arguments container, then, from key and values parsing, to validation is automatically done on app startup. 

# Install 

## Package Manager
```shell
Install-Package Cliargs.NET
```

## Dotnet CLI
```shell
dotnet add package Cliargs.NET
```


# Quick comparison 

In this example, you see the difference between managing the command line arguments by yourself, or by Cliargs.NET, for an application with two arguments:

| Argument &nbsp; &nbsp; &nbsp; &nbsp; | type | key | short key | Optional |
| :---: | :---: | :---: | :---: | :---: |
| User Name | string | --name | -n | no |
| User age | uint | --age | -a | yes |

The objective is to display the following message in a console app: 
> Dear {user name}, you're {user age} years old!


## Example of old school way: 😔

> 👉 [Example on gist](https://gist.github.com/YounesCheikh/c000e4a03ba7b545df1838b03e41474c) 👈

## New way with Cliargs.NET 🤩

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

# Documentation
> More examples and documentation is on [Wiki](https://github.com/YounesCheikh/Cliargs.NET/wiki)
