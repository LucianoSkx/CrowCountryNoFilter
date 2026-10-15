# CrowCountryCamEffectOff · [EN/PT]

[Filters disabled — before vs. after](before_after.png)

BepInEx plugin that disables all camera filters (CRT, PSX, SFB, grain, noise) in Crow Country.

## Requirements

- [BepInEx 5.4.23+](https://github.com/BepInEx/BepInEx) installed in your Crow Country folder
- [.NET SDK 6.0+](https://dotnet.microsoft.com/download) (only for building from source)

## Installation

### Windows

1. Install BepInEx 5.4.23+ to your Crow Country folder
2. Copy `CrowCountryCamEffectOff.dll` to `BepInEx/plugins/`
3. Run the game once to generate the config
4. Edit `BepInEx/config/luciano.crowcountry.camoff.cfg` if needed

### Linux (Proton/Wine)

1. Install BepInEx 5.4.23+ to your Crow Country folder
2. Copy `CrowCountryCamEffectOff.dll` to `BepInEx/plugins/`
3. Register the DLL override. Easiest (automatic):
   ```bash
   protontricks 1996010 winhttp=n
   ```
   Or add a launch option in Steam:
   ```bash
   WINEDLLOVERRIDES="winhttp=n,b" %command%
   ```
   Or set it permanently in the Wine prefix from the shell:
   ```bash
   STEAM_COMPAT_APP_ID=1996010 \
   STEAM_COMPAT_DATA_PATH="$HOME/.local/share/Steam/steamapps/compatdata/1996010" \
   proton run reg.exe add \\
     "HKCU\\Software\\Wine\\AppDefaults\\Crow Country.exe\\DllOverrides" \\
     /v winhttp /t REG_SZ /d native,builtin /f
   ```
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

Usually the script auto-detects common install paths. Override if needed:

```bash
GameDir="/path/to/Crow Country" ./build.sh
```

## How It Works

Patches `OnRenderImage` on `CrowCountryCamEffect`, `PSXEffects`, and `CRTEffect` to blit the source render texture directly to the destination, bypassing all filter processing. Also disables the components themselves.

## Uninstall

Delete `CrowCountryCamEffectOff.dll` from `BepInEx/plugins/`. Restore the original filter behavior is automatic.

## License

[MIT](LICENSE)

---

# CrowCountryCamEffectOff (PT-BR)

Plugin BepInEx que desliga todos os filtros de câmera (CRT, PSX, SFB, grain, noise) do Crow Country.

## Requisitos

- [BepInEx 5.4.23+](https://github.com/BepInEx/BepInEx) instalado na pasta do Crow Country
- [.NET SDK 6.0+](https://dotnet.microsoft.com/download) (somente para compilar do código-fonte)

## Instalação

### Windows

1. Instale o BepInEx 5.4.23+ na pasta do Crow Country
2. Copie `CrowCountryCamEffectOff.dll` para `BepInEx/plugins/`
3. Rode o jogo uma vez para gerar o config
4. Edite `BepInEx/config/luciano.crowcountry.camoff.cfg` se necessário

### Linux (Proton/Wine)

1. Instale o BepInEx 5.4.23+ na pasta do Crow Country
2. Copie `CrowCountryCamEffectOff.dll` para `BepInEx/plugins/`
3. Registre o override da `winhttp`. Mais fácil (automático):
   ```
   protontricks 1996010 winhttp=n
   ```
   Ou adicione a opção de inicialização no Steam:
   ```
   WINEDLLOVERRIDES="winhttp=n,b" %command%
   ```
   Ou configure direto via shell no prefix do Wine:
   ```
   STEAM_COMPAT_APP_ID=1996010 \\
   STEAM_COMPAT_DATA_PATH="$HOME/.local/share/Steam/steamapps/compatdata/1996010" \\
   proton run reg.exe add \\
   "HKCU\\Software\\Wine\\AppDefaults\\Crow Country.exe\\DllOverrides" \\
   /v winhttp /t REG_SZ /d native,builtin /f
   ```
4. Rode o jogo uma vez para gerar o config
5. Edite `BepInEx/config/luciano.crowcountry.camoff.cfg` se necessário

## Configuração

| Chave | Padrão | Descrição |
|-------|--------|-----------|
| `Disable All Filters` | `true` | Coloque `false` para reativar os filtros |

## Compilar do Código-Fonte

### Windows (PowerShell)

```powershell
.\build.ps1
```

### Linux / macOS

```bash
chmod +x build.sh
./build.sh
```

O script auto-detecta paths comuns. Se necessário:

```bash
GameDir="/caminho/para/Crow Country" ./build.sh
```

## Como Funciona

Patcha `OnRenderImage` em `CrowCountryCamEffect`, `PSXEffects` e `CRTEffect` para copiar a render texture de origem direto para o destino, pulando o código de filtro original. Também desabilita os próprios componentes.

## Desinstalar

Delete `CrowCountryCamEffectOff.dll` de `BepInEx/plugins/`. O comportamento original restaura automaticamente ao remover.

## Licença

[MIT](LICENSE)
