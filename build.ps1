Write-Host "============ Build ============"
dotnet build --configuration Release

Write-Host "============ Test ============"
dotnet test --configuration Release --collect "Code coverage"

Write-Host "============ Pack a NuGet package ============"
dotnet pack --configuration Release --output Dist