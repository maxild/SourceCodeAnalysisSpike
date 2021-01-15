#EditorConfig based configuration of .NET 5+ sdk-built-in analyzers (code style/quality)

The following issues track this effort

https://github.com/maxild/Domus/issues/25

Issues with answers to my many questions by @mavasani

https://github.com/dotnet/roslyn/issues/49250#issuecomment-760374529
https://github.com/dotnet/roslyn/issues/43051#issuecomment-758862927

Build on the commandline with

```bash
$ dotnet msbuild -t:rebuild -p:TreatWarningsAsErrors=true -warnaserror ./SourceCodeAnalysisSpike.sln

Microsoft (R) Build Engine version 16.8.3+39993bd9d for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

Program.cs(10,17): error CS0219: The variable 'unused' is assigned but its value is never used
Program.cs(10,17): error IDE0059: Unnecessary assignment of a value to 'unused'
Program.cs(6,35): error IDE0060: Remove unused parameter 'args'
  SourceCodeAnalysisSpike -> ./src/bin/Debug/net5.0/SourceCodeAnalysisSpike.dll
```