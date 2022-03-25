---
title: Conditional Rule
description: >-
  Cliargs.NET Documentation of native conditional validation rule
categories:
  - Validation Rules
fullview: true
order: 1
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---

The [Conditional Rule](https://github.com/YounesCheikh/Cliargs.NET/blob/main/src/Cliargs/Rules/ConditionalRule.cs) is very generic allows you to customize the condition to validate the value using lambda expressions.

## Create an instance

To create an instance of the Conditional rule, either you use the default constructor or use the static method `WithCondition`.
Example below, to set a conditional rule for integer value that must be greater than 0.

```csharp
// Default rule constructor 
new ConditionalRule<int>(value=> value> 0);

// With static method
ConditionalRule<int>.WithCondition(value => value > 0);
```

## Set the validation error message

You can customize the validation error message to show to the end-user if the validation fails by calling the method `WithValidationError(string validationError)`.

```csharp
myConditionalRule = myConditionalRule.WithValidationError("My custom validation error message");
```

## Example

```csharp
ConditionalRule<int>.WithCondition(value => value > 18)
    .WithValidationError("Age must be greater than 18 years old.");
```
