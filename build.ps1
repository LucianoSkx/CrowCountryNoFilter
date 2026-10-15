$ErrorActionPreference = "Stop"

$GameDir = if ($env:GameDir) { $env:GameDir } else { "C:\Games\Crow Country" }
$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

dotnet build "$ScriptDir\CrowCountryCamEffectOff.csproj" `
  -p:GameDir="$GameDir" `
  -c Release

Write-Host "Built: $ScriptDir\dist\CrowCountryCamEffectOff.dll"
