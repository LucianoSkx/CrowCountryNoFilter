
# CrowCountryCamEffectOff

![Before and After](before_after.png)

<p align="center"><a href="README.md">🇬🇧 English</a> · <a href="README.pt-BR.md">🇧🇷 Português</a></p>

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
