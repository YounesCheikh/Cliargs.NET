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

## Auto generation of long and short names

This setting is available since [version 1.3.0](https://github.com/YounesCheikh/Cliargs.NET/releases/tag/1.3.0). It allows you to enable or disable the auto generation of the long and short names for a specific arguments if they are not set.

To enable this feature, just set the option `CliArgsOptions.Container.AutoGenerateNames` to `true` before on app startup and before initializing AppCliArgs.

```csharp
CliArgsOptions.Container.AutoGenerateNames = true;
```

> When this option is enabled, the registration of the argument having auto generated names might fail if the container already contains another argument with the same long name or the same short name.
{: .prompt-warning }

---

> Currently not all settings are customizable, I'm working to make Cliargs more customizable than today. If you want to suggest adding more default settings to be customizable, [just let me know](https://github.com/YounesCheikh/Cliargs.NET/discussions/new?category=ideas).
{: .prompt-info }
