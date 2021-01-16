# CodeStyle severity configuration

MSBuild based configuration: Enable end-users to easily enable/disable different
well-known and recommended SDK analyzer buckets based on their preferences via
MSBuild properties which can be changed on MSBuild/compiler command line.
This feature would need to be baked into the SDK.

The below SDK MSBuild properties and their values will be implemented via generating
and embedding different well-known and recommended configuration files into the SDK.

Users that prefer explicit configuration files checked into their repo can copy
over these [configuration files](https://github.com/maxild/SourceCodeAnalysisSpike/tree/master/sdk-analyzers/microsoft.codeanalysis.csharp.codestyle.3.9.0-4.21064.16/build/config) with an entry per-rule directly to the root of
their repo and edit/maintain as appropriate. Here is the [recommended severity configurations](https://github.com/maxild/SourceCodeAnalysisSpike/blob/master/sdk-analyzers/microsoft.codeanalysis.csharp.codestyle.3.9.0-4.21064.16/build/config/AnalysisLevelStyle_Recommended.editorconfig).

| Value | Meaning |
| --- | --- |
| Default | Default mode where all CodeStyle analyzers are enabled as IDE only suggestions or refactorings. None of them are enabled as build warnings. |
| MinimumRecommended | More aggressive mode than the Default mode, where certain IDE code style suggestions that are highly recommended for build enforcement (for example, file header analyzer) are enabled as build warnings. |
| Recommended | More aggressive mode than the MinumumRecommended mode, where more IDE code style rules are as build warnings. |
| AllEnabledByDefault | Aggressive or opt-out mode, where all CodeStyle rules are enabled by default as build warnings. You can selectively opt out of individual rules to disable them in IDE and/or build. |
| AllDisabledByDefault | Conservative or opt-in mode, where all CodeStyle rules are disabled by default. You can selectively opt into individual rules to enable them in IDE and/or build. |


The below table (based on `microsoft.codeanalysis.csharp.codestyle.3.9.0-4.21064.16`)
shows the differences between the profiles (`Default` have been left out because all severities are empty):

TODO: Maybe All/None could be left out as well...Only Minimum/Recommended are interesting!

ID | Description | EnforceOnBuild | `None` | `Minimum` | `Recommended` | `All` |
| --- | ---| --- |--- | --- | --- | --- |
IDE0001 | Simplify name | Never |  |  |  |  |
IDE0002 | Simplify member access | Never |  |  |  |  |
IDE0003 | Remove 'this' qualification | Never |  |  |  |  |
IDE0004* | Remove Unnecessary Cast | WhenExplicitlyEnabled | none |  |  | warning |
IDE0005* | Using directive is unnecessary | HighlyRecommended |  |  |  |  |
IDE0007* | Use implicit type | HighlyRecommended |  |  |  |  |
IDE0008* | Use explicit type | HighlyRecommended |  |  |  |  |
IDE0009* | Add 'this' qualification | Never | none |  |  |  |
IDE0010* | Add missing cases to switch statement | WhenExplicitlyEnabled | none | | | |
IDE0011* | Add braces | HighlyRecommended |  |  |  |  |
IDE0016* | Use 'throw' expression | Recommended |  |  |  |  |
IDE0017* | Use object initializers | Recommended |  |  |  |  |
IDE0018* | Inline variable declaration | Recommended |  |  |  |  |
IDE0019* | Use pattern matching to avoid as followed by a null check | Recommended |  |  |  |  |
IDE0020* | Use pattern matching to avoid is check followed by a cast (without variable) | Recommended |  |  |  |  |
IDE0021* | Use expression body for constructors | Recommended |  |  |  |  |
IDE0022* | Use expression body for methods | Recommended |  |  |  |  |
IDE0023* | Use expression body for conversion operators | Recommended |  |  |  |  |
IDE0024* | Use expression body for operators | Recommended |  |  |  |  |
IDE0025* | Use expression body for properties | Recommended |  |  |  |  |
IDE0026* | Use expression body for indexers | Recommended |  |  |  |  |
IDE0027* | Use expression body for accessors | Recommended |  |  |  |  |
IDE0028* | Use collection initializers | Recommended |  |  |  |  |
IDE0029* | Use coalesce expression (non-nullable types) | Recommended |  |  |  |  |
IDE0030* | Use coalesce expression (nullable types) | Recommended |  |  |  |  |
IDE0031* | Use null propagation | Recommended |  |  |  |  |
IDE0032* | Use auto property | Recommended |  |  |  |  |
IDE0033* | Use explicitly provided tuple name | Recommended |  |  |  |  |
IDE0034* | Simplify 'default' expression | Recommended |  |  |  |  |
IDE0035* | Remove unreachable code | Never | | | | |
IDE0036* | Order modifiers | HighlyRecommended |  |  |  |  |
IDE0037* | Use inferred member name | WhenExplicitlyEnabled | | | | |
IDE0038 | Use pattern matching to avoid is check followed by a cast (without variable) | Recommended | | | | |
IDE0039* | Use local function instead of lambda | Recommended |  |  |  |  |
IDE0040* | Add accessibility modifiers | HighlyRecommended |  |  |  |  |
IDE0041* | Use is null check | WhenExplicitlyEnabled | | | | |
IDE0042* | Deconstruct variable declaration | Recommended |  |  |  |  |
IDE0043* | Format string contains invalid placeholder | HighlyRecommended |  |  |  |  |
IDE0044* | Add readonly modifier | HighlyRecommended |  |  |  |  |
IDE0045* | Use conditional expression for assignment | Recommended |  |  |  |  |
IDE0046* | Use conditional expression for return | Recommended |  |  |  |  |
IDE0047* | Remove unnecessary parentheses | Recommended |  |  |  |  |
IDE0048* | Add parentheses for clarity | WhenExplicitlyEnabled | | | | |
IDE0049 | Use language keywords instead of framework type names for type references | Never |  |  |  |  |
IDE0050* | Convert anonymous type to tuple | Recommended |  |  |  |  |
IDE0051* | Remove unused private member | HighlyRecommended |  |  |  |  |
IDE0052* | Remove unread private member | HighlyRecommended |  |  |  |  |
IDE0053 | Use expression body for lambdas | Recommended |  |  |  |  |
IDE0054* | Use compound assignment | Recommended |  |  |  |  |
IDE0055* | Fix formatting | HighlyRecommended |  |  |  |  |
IDE0056* | Use index operator | Recommended |  |  |  |  |
IDE0057* | Use range operator | Recommended |  |  |  |  |
IDE0058* | Remove unnecessary expression value | WhenExplicitlyEnabled | | | | |
IDE0059* | Remove unnecessary value assignment | HighlyRecommended |  |  |  |  |
IDE0060* | Remove unused parameter | HighlyRecommended |  |  |  |  |
IDE0061* | Use expression body for local functions | Recommended |  |  |  |  |
IDE0062* | Make local function static | Recommended |  |  |  |  |
IDE0063* | Use simple using statement | Recommended |  |  |  |  |
IDE0064* | Make struct fields writable | WhenExplicitlyEnabled | | | | |
IDE0065* | using directive placement | Recommended |  |  |  |  |
IDE0066* | Use switch expression | WhenExplicitlyEnabled | | | | |
IDE0070* | Use `System.HashCode.Combine` | Recommended |  |  |  |  |
IDE0071* | Simplify interpolation | Recommended |  |  |  |  |
IDE0072* | Add missing cases to switch expression | WhenExplicitlyEnabled | | | | |
IDE0073* | Require file header | HighlyRecommended |  |  |  |  |
IDE0074* | Use coalesce compound assignment | Recommended |  |  |  |  |
IDE0075* | Simplify conditional expression | Recommended |  |  |  |  |
IDE0076* | Remove invalid global `SuppressMessageAttribute` | HighlyRecommended |  |  |  |  |
IDE0077* | Avoid legacy format target in global `SuppressMessageAttribute` | HighlyRecommended |  |  |  |  |
IDE0078* | Use pattern matching | Recommended |  |  |  |  |
IDE0079 | Remove unnecessary suppression (unnecessary `pragma` and `SuppressMessageAttribute` in source) | Never | | | | |
IDE0080* | Remove unnecessary suppression operator | HighlyRecommended |  |  |  |  |
IDE0082* | Convert typeof to nameof | Recommended |  |  |  |  |
IDE0083* | Use pattern matching (not operator) | Recommended |  |  |  |  |
IDE0090 | Use 'new(...)' | Recommended |  |  |  |  |
IDE0100 | Remove unnecessary equality operator | Recommended |  |  |  |  |
IDE0110 | Remove unnecessary discard | Recommended |  |  |  |  |
IDE1005* | Use conditional delegate call | Recommended |  |  |  |  |
IDE1006* | Naming rule | Recommended |  |  |  |  |

NOTE: IDs with an "*" (asterisk) are contained in the .NET 5 assemblies (provided by the SDK)