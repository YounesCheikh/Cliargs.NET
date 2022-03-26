---
title: Handle validation errors
description: >-
  Cliargs.NET Documentation of validation error handling
categories:
  - Basic usage
fullview: true
order: 8
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---

During the initialization, Cliargs.NET execute all the defined rules for each argument, if any rule fails to get validated, Cliargs.NET registers the errors.

## Check if validation failed

To know if any rule fails to get validated during the validation process, use the static property `AppCliArgs.HasValidationErrors`.

```csharp
if(AppCliArgs.HasValidationErrors) 
{
    // Do stuff
}
```

## Get validation errors

The validation errors could be retrieved by calling the static method `AppCliArgs.GetValidationResults()`. This method returns only validation results for rules failed to get validated.

```csharp
if(AppCliArgs.HasValidationErrors)
{
    // Here you get the validation results for errors
    var validationResults = AppCliArgs.GetValidationResults();
    foreach (var result in validationResults)
    {
        // do stuff 
    }
    return;
}
```

## Validation results

The validation result contains several information about the validation, such as the rule name, the error message... or a `global report`.

> The validation result **Report** is a string contains all the information, rule, message, the usage of the argumet... [More info here](https://github.com/YounesCheikh/Cliargs.NET/blob/4cf4d68deaac37ff0a06b628aaf149f3c44528f9/src/Cliargs/CliArgsValidationResult.cs#L62)
{: .prompt-info }

```csharp
if(AppCliArgs.HasValidationErrors)
{
    var validationResults = AppCliArgs.GetValidationResults();
    foreach (var result in validationResults)
    {
        // Here you access to the results 
        Console.WriteLine(result.GetReport());
        Console.WriteLine(result.ValidationError);
        Console.WriteLine(result.RuleName);
        Console.WriteLine(result.ArgName);
        Console.WriteLine(result.Usage);
    }

    return;
}
```
