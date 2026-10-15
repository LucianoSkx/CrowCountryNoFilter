# CrowCountryCamEffectOff

![Before and After](before_after.png)

A BepInEx plugin that disables all camera filters (CRT, PSX, SFB, grain, noise) in Crow Country.

## Requirements

- [BepInEx 5.4.23+](https://github.com/BepInEx/BepInEx) installed in your Crow Country directory
- [.NET SDK 6.0+](https://dotnet.microsoft.com/download) (only for building from source)

## Installation

### Windows

1. Install BepInEx 5.4.23+ to your Crow Country folder
2. Copy `CrowCountryCamEffectOff.dll` to `BepInEx/plugins/`
3. Run the game once to generate the config
4. Edit `BepInEx/config/luciano.crowcountry.camoff.cfg` if needed

### Linux (Proton/Wine)

1. Install BepInEx 5.4.23+ to your Crow Country folder
2. Register the DLL override in the Wine prefix:
   ```
   [Software\\Wine\\AppDefaults\\Crow Country.exe\\DllOverrides]
   "winhttp"="native,builtin"
   ```
3. Copy `CrowCountryCamEffectOff.dll` to `BepInEx/plugins/`
4. Run the game once to generate the config
5. Edit `BepInEx/config/luciano.crowcountry.camoff.cfg` if needed

## Configuration

| Key | Default | Description |
|-----|---------|-------------|
| `Disable All Filters` | `true` | Set to `false` to re-enable filters |

## Building from Source

### Windows (PowerShell)

```powershell
.\build.ps1
```

### Linux / macOS

```bash
chmod +x build.sh
./build.sh
```

Set the `GameDir` environment variable if your game is not in the default location:

```bash
GameDir="/path/to/Crow Country" ./build.sh
```

## How It Works

Patches `OnRenderImage` on `CrowCountryCamEffect`, `PSXEffects`, and `CRTEffect` to blit the source render texture directly to the destination, bypassing all filter processing. Also disables the components themselves.

## License

MIT
