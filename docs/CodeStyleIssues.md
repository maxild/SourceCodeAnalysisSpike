### Usings

```ini
# Sort System.* using directives alphabetically, and place them before other using directives.
dotnet_sort_system_directives_first = true
# Do not place a blank line between using directive groups.
dotnet_separate_import_directive_groups = false
```

Some IDxxxx should be triggered, but it seems the warning/error is ignored even by live analysis in vs2019 (error list) and or vscode (problems).

The format rule `dotnet_sort_system_directives_first` also cannot be found [in the docs/index](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/#index).

### It seems that the following IDs cannot fail the commandline build and they are only shown by live analysis (error list in vs2019, problems in omnisharp/vscode)

This is even when the project is configured as specified in the docs

```xml
<PropertyGroup>
    <!-- .NET code style analysis is disabled, by default -->
    <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
  </PropertyGroup>
```

and commendline sets both `/warnaserror` and `/p:TreatWarningsAsErrors=true`:

```bash
$ dotnet msbuild -t:Rebuild -p:TreatWarningsAsErrors=true -warnaserror ./SourceCodeAnalysisSpike.sln
```

- IDE0005: Using directive is unnecessary.
