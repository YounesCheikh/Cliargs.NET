---
title: Argument long and short names
description: >-
  Cliargs.NET Documentation for argument long and short names
categories:
  - Basic usage
fullview: true
order: 3
date: 2022-03-22 00:00:00 +0100
last_modified_at: 2022-03-22 00:00:00 +0100
published: true
---

The argument long and short names are different than the argument name. The argument name is used as a key when managing the arguments, ex: create argument or get a value of an argument.

## Argument long name 
The argument long name is usually a single word or a set of words separated by a dash `-` all in lower case. 

### Argument without value
```csharp 
var myOptionArg = CliArg.New("ForceUpdate")
                    .WithLongName("force-update");
```

**Usage**

```shell
> myApp --force-update
```

### Argument with value

```csharp
var myOtherArg = CliArg.New<bool>("ForceUpdate")
                    .WithLongName("force-update");
```

**Usage**

```shell
> myApp --force-update true
```

--- 
## Argument short name 
The argument short name is usually a single character or an abbreviation of multiple words in lower case. 

### Argument without value
```csharp 
var myOptionArg = CliArg.New("ForceUpdate")
                    .WithShortName("f");
```

**Usage**

```shell
> myApp -f
```

### Argument with value

```csharp
var myOtherArg = CliArg.New<bool>("ForceUpdate")
                    .WithShortName("f");
```

**Usage**

```shell
> myApp -f true
```