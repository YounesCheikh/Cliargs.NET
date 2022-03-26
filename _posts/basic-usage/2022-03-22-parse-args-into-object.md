---
title: Parse argument into object
description: >-
  Cliargs.NET Documentation of the arguments parsing into object
categories:
  - Basic usage
fullview: true
order: 7
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---

Cliargs.NET allows to parse all arguments into a given object properties, this operation is done in several steps.

## Set argument properties

Each property that corresponds to an argument must have the same type as the argument and has an attribute `CliArgNameAttribute`.

### Example

If you have set an argument Age with type `uint` like the following:

```csharp
container.Register(
                CliArg.New<uint>("UserAge")
                .WithLongName("age")
                .WithShortName("a")
            );
```

Then the property where the data is parsed it should be similar than in the following code:

```csharp
public class MyArgs
    {
        [CliArgName("UserAge")]
        public uint? Age {get; set;}
    }
```

> The attribute `CliArgName` has an optional parameter `string? name = default` which is the name of the argument (in the example above is UserAge). Setting the argument name is not required if the property has the same name than the argument.
{: .prompt-tip }

## Parse the data

Once Cliargs initiliazation is completed without errors, you can start the parsing by calling the method `GetArgsParsed<TObj>()`.

```csharp
MyArgs myArgs;

try {
    AppCliArgs.Initialize<CliArgsSetup>();
    // Parse the data into a give args object (MyArgs)
    myArgs = AppCliArgs.GetArgsParsed<MyArgs>();
}
catch(CliArgsException exception){
    Console.WriteLine($"Error: {exception.Message}");
    return;
} 

// Later you access to the property from everywhere 
Console.WriteLine($"User age: {myArgs.Age}.");
```
