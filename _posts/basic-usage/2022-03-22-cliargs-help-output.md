---
title: Help output
description: >-
  Cliargs.NET Documentation of Cliargs Help output 
categories:
  - Basic usage
fullview: true
order: 6
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---

Cliargs.NET generates automatically the help output during the initialization step basing on the container configuration. The help output is composed of two columns, the left one is the argument usage, and the right one is the description as set by the developer.
If the argument is optional has a default value set, this default value is displayed on the description column.

To get the help output use the static method `GetHelpString()`.

```csharp
Console.WriteLine(AppCliArgs.GetHelpString());
```

To check if the end-user has requested to see the help, use the static method `IsHelpRequested()`.

```csharp
if(AppCliArgs.IsHelpRequested()) {
    Console.WriteLine(AppCliArgs.GetHelpString());
    return;
}
```

## Example output

