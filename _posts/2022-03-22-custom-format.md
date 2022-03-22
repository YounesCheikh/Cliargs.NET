---
title: Custom Format
description: >-
  Cliargs.NET Documentation on how to customize the input format
categories:
  - Advanced usage
fullview: true
order: 1
date: 2022-03-05 00:23:00 +0100
last_modified_at: 2022-03-05 00:23:00 +0100
published: true
---

The format is the definition of the prefix for long name and short name of arguments, and the assignation character for setting a value to an argument, this character or symbol is usually located between the argument key and the value, `--arg-key=value`. 

### Native Format 
The default native format is `--long-argument-name argValue -short-name value --option` 

### Custom Format

The customize the input format you can create your own format class by implementing the base class `CliArgsFormat`. 

```csharp
public class CustomFormat : CliArgsFormat
    {
        public CustomFormat() : base(':', "/:", "/") { }
    }
```

Then from main specify the Input format to use during the initialization : 
```csharp 
AppCliArgs.Initialize<CliArgsSetup>(new CustomFormat());
```

Other easy way to do is by creating a new instance from the default format and set the arguments from constructor:

```csharp
// /:long-name=vlaue /short=other-value
AppCliArgs.Initialize<CliArgsSetup>(new CliArgsFormat('=', "/:", "/"));
```