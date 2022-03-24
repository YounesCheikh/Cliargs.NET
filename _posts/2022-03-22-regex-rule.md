---
title: Regex Rule
description: >-
  Cliargs.NET Documentation of native regular expression rule
categories:
  - Validation Rules
fullview: true
order: 2
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---

The [Regex Rule](https://github.com/YounesCheikh/Cliargs.NET/blob/main/src/Cliargs/Rules/RegexRule.cs) is a validation rule allows you to validate the user input using a regular expression pattern.  

## Create an instance

To create an instance of the Regex rule, either you use the default constructor or use the static method `WithPattern(string pattern)`.
Example below, to set a conditional rule for integer value that must be greater than 0.

```csharp
// Default rule constructor 
new RegexRule(".*");

// With static pattern method
RegexRule.WithPattern(".*");
```

If you are familiar with Regular Expressions on C#, you can specify the Regex Options.

```csharp
// Default rule constructor 
new RegexRule(".*",  RegexOptions.IgnoreCase);

// With static pattern method
RegexRule.WithPattern(".*",  RegexOptions.IgnoreCase);
```

## Set the validation error message

You can customize the validation error message to show to the end-user if the validation fails by calling the method `WithValidationError(string validationError)`.

```csharp
myConditionalRule = myConditionalRule.WithValidationError("My custom validation error message");
```

## Example

```csharp
var regexRule = RegexRule.WithPattern("\d")
            .WithValidationError("The value doesn't match the defined pattern, only numbers expected.");
```
