# OmniMovement

A BepInEx mod for Mycopunk that makes ground movement speed consistent in all directions (forward, strafe, backward,
diagonals, and slide strafe).

## Features

- **Omnidirectional ground speed**: Forward, strafe, backward, and diagonal movement all use the same speed
- **Slide strafe**: Lateral input while sliding is no longer reduced
- Sprint already ignored vanilla strafe penalties; this mod extends full-speed movement to walking, backpedaling, and
  sliding

## Dependencies

- Mycopunk
- [BepInEx Pack for Mycopunk](https://thunderstore.io/c/mycopunk/p/BepInEx/BepInExPack_Mycopunk/) 5.4.2403 or compatible

## Installation

### Thunderstore (recommended)

1. Install via a Thunderstore mod manager (for example, r2modman or the Thunderstore App)
2. The mod is placed in the correct plugins folder automatically

### Manual

1. Install BepInEx for Mycopunk
2. Copy `OmniMovement.dll` into `<Mycopunk Directory>/BepInEx/plugins/`

The mod loads automatically with BepInEx. Confirm it in the BepInEx log:

```text
OmniMovement v2.0.0 loaded successfully.
```

## Configuration

Settings are written to:

```text
<Mycopunk Directory>/BepInEx/config/sparroh.omnimovement.cfg
```

| Setting              | Default | Description                                                                                                        |
|----------------------|---------|--------------------------------------------------------------------------------------------------------------------|
| Enable Omni Movement | `true`  | Makes ground movement speed consistent in all directions (forward, strafe, backward, diagonals, and slide strafe). |

Config changes on disk are hot-reloaded while the game is running (no restart required).

## How it works

Vanilla movement normalizes stick/keyboard input, then multiplies strafe and backward axes before building the move
direction (without re-normalizing). Those multipliers are what make side and reverse movement slower.

This mod sets the following multipliers to `1` on player awake and every movement tick:

- `strafeSpeedMultiplier`
- `strafeSpeedMultiplierWhileMoving`
- `backwardSpeedMultiplier`
- `slideStrafeMultiplier`

## Building

Requirements for local builds:

- .NET SDK with `netstandard2.1` support
- Game assemblies referenced from your Mycopunk install (see the project file)
- BepInEx core assemblies

```bash
dotnet build --configuration Release
```

Output DLL:

```text
bin/Release/netstandard2.1/OmniMovement.dll
```

## Troubleshooting

- **Mod not loading?** Confirm BepInEx is installed and check the BepInEx log for errors
- **Movement unchanged?** Ensure `Enable Omni Movement` is `true` in the config (changes hot-reload from disk)

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Author

- Sparroh
