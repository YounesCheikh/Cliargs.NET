---
title: Argument Info
description: >-
  Cliargs.NET Documentation of the argument properties and info
categories:
  - Basic usage
fullview: true
order: 1
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: false
---

The Argument Info is the `metadata` of each command line argument registered to Cliargs.NET. It contains all the information about the argument, such as required or optional, the description, the usage example...

### Name

The name is mandatory for each argument, it is used as a key to retrieve the data from the Cliargs.NET Container.

Specify the key when creating a new argument instance:

```csharp
CliArg.New("ArgWithoutValue"); // The argument name here is 'ArgWithoutValue'
CliArg.New<int>("ArgWithIntValue"); // The argument name here is 'ArgWithIntValue'
```

### Optional

This property indicates whether the argument is optional or required.
> By default all arguments are created as required.
To set an argument as optional or required, either you use the property setter or use the extension methods `AsRequired()` or `AsOptional()` during the argument instance creation.

```csharp
// Setting the Argument Info property 
var usernameArg = new CliArg<string>(new CliArgsInfo("Username"));
usernameArg.Info.Optional = true; // or false even if is default. 

// Setting during the argument creation 
// Set it as optional
var usernameArg = CliArg.New<string>("Username")
                .AsOptional();

// Set it as required
usernameArg = CliArg.New<string>("Username")
                .AsRequired();
```

### Long Name and Short Name

The long name and the short name are both the main keys for the CLI input, both are optional, could be set together, or only one from both.
> If both long name and short name are not set, Cliargs.NET will lookup for an input with argument Name.

In the CLI input, Cliargs.NET expects to have the long name preceded with the format LongNamePrefix, default is `--`, example `--long-name` , and have the short name preceded with format ShortNamePrefix, default is `-`, example `-short-name`.

The long name and the short name could be set during the argument creation:

```csharp
 var username = CliArg.New<string>("Username")
                .WithLongName("user")
                .WithShortName("u");
```

### Description

The argument description is usually used to be displayed on help output to describe the role of an argument.

```csharp
var username = CliArg.New<string>("Username")
                .WithLongName("user")
                .WithShortName("u")
                .WithDescription("The username with no space"); // Extension method to set the description
```

### Usage

The argument usage is an example displayed to the user when an error occures during the parsing process or in case of a missing value.

```csharp
var username = CliArg.New<string>("username")
                .WithLongName("user")
                .WithShortName("u")
                .WithUsage("--user JohnDoe"); // This will be displayed in case of an error
```

### Validation Rules

Each argument has a set of rules to validate the value once parsed. This rules could be added one by one using the method `WithValidationRule` or added all together using the method `WithValidationRules`.

```csharp
// single validation rule
var username = CliArg.New<string>("Username")
                .WithShortName("u")
                .WithDescription("The username starting with J")
                .WithUsage("--user John")
                .ValidatedWithRule(
                    // The following rule ensures the user is starting with J.
                    ConditionalRule<string>.WithCondition(
                        s=> s.StartsWith("J"))
                    WithValidationError("User name must start with J")
                );

// a set of rules
var month = CliArg.New<uint>("Month")
                .WithShortName("m")
                .WithDescription("The month from 1 to 12")
                .WithUsage("--month 10 | -m 10")
                .ValidatedWithRules(
                    // Rule for month to be >= 1 and <= 12
                     GreaterThanOrEqualsRule<uint>.Value(1),
                     LessThanOrEqualsRule<uint>.Value(12)
                );
```

### Value to Typed Value Converter

For the basic type arguments (such as `Integer`, `String`, `Boolean`... ) the default converter `ValueTypeConverter` works fine, however, for some custom complex type, you may need to create your own converter in order to implement the correct way for converting the value from the input string to a typed value.
> For Enumerations, The library Cliargs.NET comes with a native converter named `StringToEnumConverter`.

```csharp
var customArg = CliArg.New<CustomType>("Arg")
                .WithShortName("ar")
                .ValueConvertedWith(new MyCustomConverter());
```
