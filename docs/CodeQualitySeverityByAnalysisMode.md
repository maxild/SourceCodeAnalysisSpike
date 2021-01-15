# CodeQuality severity configuration

MSBuild based configuration: Enable end-users to easily enable/disable different
well-known and recommended SDK analyzer buckets based on their preferences via
MSBuild properties which can be changed on MSBuild/compiler command line.
This feature would need to be baked into the SDK.

The below SDK MSBuild properties and their values will be implemented via generating
and embedding different well-known and recommended configuration files into the SDK.

Users that prefer explicit configuration files checked into their repo can copy
over these [configuration files](https://github.com/maxild/SourceCodeAnalysisSpike/tree/master/sdk-analyzers/microsoft.codeanalysis.netanalyzers.5.0.3/build/config) with an entry per-rule directly to the root of
their repo and edit/maintain as appropriate. Here is the [recommended severity configurations](https://github.com/maxild/SourceCodeAnalysisSpike/blob/master/sdk-analyzers/microsoft.codeanalysis.netanalyzers.5.0.3/build/config/AnalysisLevelDesign_5_recommended.editorconfig) for all of the categories. There are also
individual category based files as seen by the [Naming recommended config](https://github.com/maxild/SourceCodeAnalysisSpike/blob/master/sdk-analyzers/microsoft.codeanalysis.netanalyzers.5.0.3/build/config/AnalysisLevelNaming_5_recommended.editorconfig).

| Value | Meaning |
| --- | --- |
| Default | Default mode where all CodeStyle analyzers are enabled as IDE only suggestions or refactorings. None of them are enabled as build warnings. |
| MinimumRecommended | More aggressive mode than the Default mode, where certain IDE code style suggestions that are highly recommended for build enforcement (for example, file header analyzer) are enabled as build warnings. |
| Recommended | More aggressive mode than the MinumumRecommended mode, where more IDE code style rules are as build warnings. |
| AllEnabledByDefault | Aggressive or opt-out mode, where all CodeStyle rules are enabled by default as build warnings. You can selectively opt out of individual rules to disable them in IDE and/or build. |
| AllDisabledByDefault | Conservative or opt-in mode, where all CodeStyle rules are disabled by default. You can selectively opt into individual rules to enable them in IDE and/or build. |


The below table shows the differences between the profiles (`Default` have been left out because all severities are empty):

TODO: Maybe All/None could be left out as well...Only Minimum/Recommended are interesting!

NOTE: Rules that are first released in a version later than '5.0' are disabled.

This must be done per category:
- Design
- Documentation
- Globalization
- Interoperability
- Maintainability
- Naming
- Performance
- Publish
- Reliability
- Security
- Usage

Example

ID | Description | `None` | `Minimum` | `Recommended` | `All` |
| --- | --- |--- | --- | --- | --- |
CA1000 | Do not declare static members on generic types | none | warning | warning | warning |
