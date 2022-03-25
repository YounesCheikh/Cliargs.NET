---
title: Argument Usage
description: >-
  Cliargs.NET Documentation of the argument usage property
categories:
  - Basic usage
fullview: true
order: 5
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---

Argument usage is a sample description explaining the usage of the argument, including the short and long names and format.
Once the argument usage is set, if the user enters a wrong value, the usage set will be displayed as a hint to help the user correct the input.
> The argument usage is displayed on the first column on the help output.
{: .prompt-tip }

## Usage example

```csharp
public void Configure(ICliArgsContainer container)
        {
            // The user real name
            container.Register(
                CliArg.New<string>("Name")
                .WithLongName("name")
                .WithShortName("n")
                .WithDescription("The real name")
                // Here is the example usage
                .WithUsage($"-n|--name \"John Doe\"")
                .ValidatedWithRule(RegexRule.WithPattern("/^[a-z ,.'-]+$/i"))
            );
        }
```

## Result on wrong input

![Argument usage](/images/argument-usage-on-wrong-input.png)

## Result on help requested

![Argument usage on help](/images/argument-usage-help.png)
> To generate a correct help output, Cliargs is generating automatically the argument usage if not set.
{: .prompt-tip }
