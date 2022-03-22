---
title: Create argument
description: >-
  Cliargs.NET Documentation of native conditional validation rule
categories:
  - Basic usage
fullview: true
order: 2
date: 2022-03-05 00:23:00 +0100
last_modified_at: 2022-03-05 00:23:00 +0100
published: true
---

The argument creation is the first step to setup your configuration, you should know what is the type of the argument's value, or if the argument is an option without any expected value.

### Sample argument with no-value

This is useful when providing the end-user possiblity to input options that don't require any value. like `--help` or `--force`. These are options, and must be handled in a different way.

```csharp
var myOptionArg = CliArg.New("Force");
```

The code above create a new instance of an argument having a name `Force`. if no long name is set, the user must enter `--Force` during the input.  

### Sample argument with a value

The arguments with value are used if you expect the user to enter an argument following with a value, ex: `--Force true`. 

```csharp
var myOptionArg = CliArg.New<bool>("Force");
```

The code above create a new instance of an argument having a name `Force` and a value of type `bool`. if no long name is set, the user must enter `--Force true` or `--Force false` during the input.
