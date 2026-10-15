#!/bin/bash
set -e

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

# Allow override via env or argument
GAMEDIR="${GameDir:-${1:-}}"

# Try common install paths
if [ -z "$GAMEDIR" ]; then
  for c in \
    "/mnt/games/SteamLibrary/steamapps/common/Crow Country" \
    "$HOME/Games/Crow Country" \
    "C:/Games/Crow Country" \
    "/mnt/*/SteamLibrary/steamapps/common/Crow Country"; do
    if [ -f "$c/BepInEx/core/BepInEx.dll" ]; then
      GAMEDIR="$c"; break; fi
  done
fi

if [ -z "$GAMEDIR" ] || [ ! -f "$GAMEDIR/BepInEx/core/BepInEx.dll" ]; then
  echo "ERROR: Crow Country install not found."
  echo "Set GameDir or pass the game path:  GameDir='/path/to/Crow Country' ./build.sh"
  exit 1
fi

echo "Building with game dir: $GAMEDIR"
dotnet build "$SCRIPT_DIR/CrowCountryCamEffectOff.csproj" \
  -p:GameDir="$GAMEDIR" -c Release
echo "OK: $SCRIPT_DIR/dist/CrowCountryCamEffectOff.dll"
