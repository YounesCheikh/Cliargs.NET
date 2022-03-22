---
title: Value Converters
description: >-
  Cliargs.NET Documentation on how to customize the arguments values conversion
categories:
  - Advanced usage
fullview: true
order: 2
date: 2022-03-05 00:00:00 +0100
last_modified_at: 2022-03-05 00:23:00 +0100
published: true
---

The input value is usually converted automatically from string to the argument predefined type, however, in some specific case, you need to customize the conversion behavior, for example, to make short input to help the end-user types in easy and quick way.

### Native Converters

#### Default Converter
The default converter is `ValueTypeConverter`

#### Enum Converter 
The converter is `StringToEnumConverter`

### Custom Converters  
To customize a conversion from the input value, you should create a new class implementing `ValueTypeConverter`;

#### Definition
In the following example, a sample custom converter to convert input values to a named script in the following : 

```
"1" => typeof(uint)
"2" => typeof(int)
"3" => typeof(long)
by default, any other value returns typeof(short)
```

```csharp
public class CustomConverter: ValueTypeConverter
{
    public override object? GetConverted(Type type, string value)
    {
        switch(value) {
            case "1" : {
                return typeof(uint);
            }
            case "2" : {
                return typeof(int);
            }
            case "3" : {
                return typeof(long);
            }
            default: {
                return typeof(short);
            }
        }
    }
}
```

#### Usage 
Once the custom converter is created, it might be used during the creation of the argument in the Setup class using the `CliArg` extension method `ValueConvertedWith()`. 

```csharp
container.Register(
                CliArg.New<Type>("TargetType")
                .AsOptional()
                .WithLongName("target-type")
                .WithShortName("tt")
                .WithDescription("Choose a target type [1, 2, 3, 4]")
                .WithUsage("-tt|--target-type <type number>")
                .ValueConvertedWith(new CustomConverter())
            );
```