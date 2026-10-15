#!/bin/bash
set -e

GAMEDIR="${GameDir:-/mnt/games/SteamLibrary/steamapps/common/Crow Country}"
SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

dotnet build "$SCRIPT_DIR/CrowCountryCamEffectOff.csproj" \
  -p:GameDir="$GAMEDIR" \
  -c Release

echo "Built: $SCRIPT_DIR/dist/CrowCountryCamEffectOff.dll"
