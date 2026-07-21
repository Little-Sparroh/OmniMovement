# Omni Movement

A BepInEx mod for Mycopunk that makes ground movement speed consistent in all directions.

## Features

- **Omnidirectional ground speed**: Forward, strafe, backward, and diagonal movement all use the same speed.
- **Slide strafe**: Lateral input while sliding is no longer reduced.
- Sprint already ignored vanilla strafe penalties; this mod extends full-speed movement to walking, backpedaling, and sliding.

## Getting Started

### Dependencies

* Mycopunk (base game)
* [BepInEx](https://github.com/BepInEx/BepInEx) - Version 5.4.2403 or compatible
* .NET Framework 4.8
* [HarmonyLib](https://github.com/pardeike/Harmony) (included via NuGet)

### Building/Compiling

1. Clone this repository
2. Open the solution file in Visual Studio, Rider, or your preferred C# IDE
3. Build the project in Release mode to generate the .dll file

Alternatively, use dotnet CLI:
```bash
dotnet build --configuration Release
```

### Installing

**Via Thunderstore (Recommended)**:
1. Download and install via Thunderstore Mod Manager
2. The mod will be automatically installed to the correct directory

**Manual Installation**:
1. Place the built `OmniMovement.dll` in your `<Mycopunk Directory>/BepInEx/plugins/` folder

### Executing program

The mod loads automatically through BepInEx when the game starts. Check the BepInEx console for loading confirmation messages.

## Configuration

Access mod settings through the BepInEx configuration file at `<Mycopunk Directory>/BepInEx/config/sparroh.omnimovement.cfg`:

| Setting | Default | Description |
|---------|---------|-------------|
| Enable Omni Movement | `true` | Makes ground movement speed consistent in all directions. |

## How it works

Vanilla movement normalizes stick/keyboard input, then multiplies strafe and backward axes before building the move direction (without re-normalizing). Those multipliers are what make side and reverse movement slower. This mod sets them to `1` so direction no longer changes speed.

## Help

* **Mod not loading?** Verify BepInEx is installed correctly and check console logs for errors
* **Movement unchanged?** Ensure the config option is enabled and restart the game

## Authors

- Sparroh

## License

This project is licensed under the MIT License - see the LICENSE file for details
