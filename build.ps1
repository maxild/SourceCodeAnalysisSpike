#!/usr/bin/env pwsh

dotnet restore ./SourceCodeAnalysisSpike.sln
dotnet msbuild -t:rebuild -p:TreatWarningsAsErrors=true -warnaserror ./SourceCodeAnalysisSpike.sln