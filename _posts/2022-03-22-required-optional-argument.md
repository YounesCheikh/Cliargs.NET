---
title: Required and Optional Arguments
description: >-
  Cliargs.NET Documentation for required and/or optional arguments
categories:
  - Basic usage
fullview: true
order: 3
date: 2022-03-23 00:00:00 +0100
last_modified_at: 2022-03-23 00:00:00 +0100
published: true
---

The difference between required and optional arguments, is that Cliargs.NET throws an exception during the initlization process when missing a required argument, while continues the initialization in a normal way if any optional argument is missing.

> Each argument is created by default as required unless you make it optional
{:.prompt-info}

## Required argument

Arguments are created as required by default, but if needed, to set an argument as required, you have two ways to follow, either by setting the `ArgumentInfo.Optional` property to `false`, or by calling the extension method `AsRequired` when creating your argument instance during the registration step.

```csharp
// Setting the Argument Info property 
var usernameArg = new CliArg<string>(new CliArgsInfo("Username"));
usernameArg.Info.Optional = false; // default is false. 

// Setting during the argument creation 
// Set it as optional
var usernameArg = CliArg.New<string>("Username")
                .AsRequired();
```

## Optional argument

To set an argument as optional, you have two ways to follow, either by setting the `ArgumentInfo.Optional` property to `true`, or by calling the extension method `AsOptional` when creating your argument instance during the registration step.

```csharp
// Setting the Argument Info property 
var usernameArg = new CliArg<string>(new CliArgsInfo("Username"));
usernameArg.Info.Optional = true; // or false even if is default. 

// Setting during the argument creation 
// Set it as optional
var usernameArg = CliArg.New<string>("Username")
                .AsOptional();
```

## Argument with default value

An optional argument could have a default value, this value is used as argument value if the end-user doesn't provide the value for the argument.
The default value is set when creating the instance of the argument during the registration step, by calling the method `AsOptional(defaultValue)`.

```csharp
// Setting during the argument creation 
// Set it as optional
var usernameArg = CliArg.New<string>("Username")
                .AsOptional("Guest"); // The default username is guest
```

> Required arguments have no default value. The value must be entered by the user.
{:.prompt-info}
