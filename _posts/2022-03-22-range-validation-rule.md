---
title: Value in Range Rule
description: >-
  Cliargs.NET Documentation of native rule to validate if value in range
categories:
  - Validation Rules
fullview: true
order: 4
date: 2022-03-05 00:23:00 +0100
last_modified_at: 2022-03-05 00:23:00 +0100
published: true
---

This rule checks if a given value is present in a range. 

### Example
This example to ensure an input Integer value is in a range of [1, 2, 3]

```csharp 
// pass the items of the range
RangeValidationRule<int?>.FromRange(1, 2, 3 ); 

// Or create a range from a collection
RangeValidationRule<int?>.FromRangeCollection(new int?[] { 1, 2, 3 });
```
