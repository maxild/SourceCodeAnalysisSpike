# EditorConfig based configuration of .NET 5+ sdk-built-in analyzers (code style/quality)

The following issues track this effort

https://github.com/maxild/Domus/issues/25

Issues with answers to my many questions by @mavasani

https://github.com/dotnet/roslyn/issues/49250#issuecomment-760374529
https://github.com/dotnet/roslyn/issues/43051#issuecomment-758862927

Build on the commandline with

```
$ dotnet msbuild -t:rebuild -p:TreatWarningsAsErrors=true -warnaserror ./SourceCodeAnalysisSpike.sln

Microsoft (R) Build Engine version 16.8.3+39993bd9d for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

Program.cs(10,17): error CS0219: The variable 'unused' is assigned but its value is never used
Program.cs(10,17): error IDE0059: Unnecessary assignment of a value to 'unused'
Program.cs(6,35): error IDE0060: Remove unused parameter 'args'
  SourceCodeAnalysisSpike -> ./src/bin/Debug/net5.0/SourceCodeAnalysisSpike.dll
```

## Some IDxxx disgnostrics are never checked

See https://github.com/dotnet/roslyn/blob/master/src/Analyzers/Core/Analyzers/EnforceOnBuildValues.cs

The following disgnostics are never checked via EnforceOnBuild=EnforceCodeStyleInBuild=true prop:

- IDE0001: Simplify names (Allow enforcing simplify names and related diagnostics on build once we validate their performance charactericstics.)
- IDE0002: Simplify member access
- IDE0003: Remove this qualification
- IDE0009: Add this qualification
- IDE0035: Remove unreachable code
- IDE0049: Use language keywords instead of framework type names for type references
- IDE0079: Remove unnecessary suppression

## C# Coding Style (BCL code styles)

The when_multiline option was developed to support the [C# Coding Style](https://github.com/dotnet/runtime/blob/master/docs/coding-guidelines/coding-style.md) used for .NET Core and it's runtime libraries, along with most related open source projects (e.g. dotnet/roslyn).

