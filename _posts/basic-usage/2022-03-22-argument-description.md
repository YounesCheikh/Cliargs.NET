---
title: Argument Description
description: >-
  Cliargs.NET Documentation of the argument description
categories:
  - Basic usage
fullview: true
order: 4
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---

The argument description is used usually when displaying a help on user demand. Each argument should have a short description to help user understand what it means.

## Set argument description

The argument description could be set either by using the `Description` property of the argument info, or by calling the extension method `WithDescription`.

```csharp
// Setting the Argument Info property 
var usernameArg = new CliArg<string>(new CliArgsInfo("Username"));
usernameArg.Info.Description = "The user name in lower case"; 

// Setting during the argument creation 
var otherArg = CliArg.New<string>("Username")
                .WithDescription("The user name in lower case");
```

## Example on results

![Description Help](/images/show-description.png)
