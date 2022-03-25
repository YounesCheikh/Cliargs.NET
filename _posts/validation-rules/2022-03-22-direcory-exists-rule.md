---
title: Directory exists
description: >-
  Cliargs.NET Documentation of native directory existance
categories:
  - Validation Rules
fullview: true
order: 5
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---


This rule ensure that a directory exists from a given path.

**Usage:**

Just add a new instance of `DirectoryExistsRule` to argument validation rules when initializing the directory argument object.

```csharp
myDirectoryArg = myDirectoryArg.WithValidationRule(new DirectoryExistsRule());
```
