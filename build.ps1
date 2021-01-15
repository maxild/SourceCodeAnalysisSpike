#!/usr/bin/env pwsh

dotnet msbuild -t:rebuild -p:TreatWarningsAsErrors=true -warnaserror .\SourceCodeAnalysisSpike.sln