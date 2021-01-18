#!/usr/bin/env pwsh

dotnet restore ./SourceCodeAnalysisSpike.sln
# cannot use 'dotnet build' (https://github.com/dotnet/msbuild/issues/3046)
dotnet msbuild -t:rebuild -p:TreatWarningsAsErrors=true -warnaserror ./SourceCodeAnalysisSpike.sln