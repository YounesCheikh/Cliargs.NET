---
title: Comparaison rules
description: >-
  Cliargs.NET Documentation of native comparaision validation rules
categories:
  - Validation Rules
fullview: true
order: 3
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---

Cliargs comes with some native rules for comparing some dotnet types (Integer, Double...). This rules could be used directly or customized. 

## EqualsRule
This rule checks whether a given value equals to another one. 

```csharp
// Create a new instance using the constructor 
new EqualsRule<string>("Sample String");

// Or use the Value method to get a new instance
EqualsRule<int>.Value(3); 
```

## GreaterThanRule

This rule checks if a given value is greater than another value. 

```csharp
// Use the rule constructor to create a new instance 
new GreaterThanRule<string>("C");

// Or Use the static `Value` method to get a new instance
GreaterThanRule<int>.Value(1);
```

## GreaterThanOrEqualsRule 

This rule is similar to [GreaterThanRule](#greaterthanrule) but it checks if a given value is greater than or equals to another value. 

```csharp
// Create a new instance using the rule constructor 
new GreaterThanOrEqualsRule<FakeEnum>(FakeEnum.EnumElement); 

// Use the static `Value` method to get a new instance
GreaterThanOrEqualsRule<int>.Value(1);
```

## LessThanRule

This rule checks if a given value is less than another value. 

```csharp
// Use the rule constructor to create a new instance 
new LessThanRule<string>("C");

// Or Use the static `Value` method to get a new instance
LessThanRule<int>.Value(1);
```

## LessThanOrEqualsRule 

This rule is similar to [LessThanRule](#lessthanrule) but it checks if a given value is less than or equals to another value. 

```csharp
// Create a new instance using the rule constructor 
new LessThanOrEqualsRule<FakeEnum>(FakeEnum.EnumElement); 

// Use the static `Value` method to get a new instance
LessThanOrEqualsRule<int>.Value(1);
```