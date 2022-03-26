---
title: Customize default settings
description: >-
  Cliargs.NET Documentation on how to customize defulat Settings
categories:
  - Advanced usage
fullview: true
order: 3
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---

Cliargs.NET comes with some default settings, which could be customized easily.

## Help argument

The help argument is registered by default by Cliargs.NET during initialization process, this argument is registered with:

- Name: `Help`
- LongName: `help`
- shortName: `h`

You can customize to any other values by setting properties of `Cliargs.CliArgsOptions.HelpArg`.

```csharp
Cliargs.CliArgsOptions.HelpArg.Name = "DefaultHelp";
Cliargs.CliArgsOptions.HelpArg.LongName = "default-help";
Cliargs.CliArgsOptions.HelpArg.ShortName = "dh";
```

---

> Currently not all settings are customizable, I'm working to make Cliargs more customizable than today. If you want to suggest adding more default settings to be customizable, [just let me know](https://github.com/YounesCheikh/Cliargs.NET/discussions/new?category=ideas).
{: .prompt-info }
