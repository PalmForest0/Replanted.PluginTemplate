# PvZ: Replanted BepInEx Plugin Template

[![NuGet Version](https://img.shields.io/nuget/v/Replanted.PluginTemplate.svg?style=for-the-badge&color=brightgreen)](https://www.nuget.org/packages/Replanted.PluginTemplate)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Replanted.PluginTemplate.svg?style=for-the-badge&color=blue)](https://www.nuget.org/packages/Replanted.PluginTemplate)

A simple [BepInEx](https://github.com/BepInEx/BepInEx) plugin template for modding **Plants vs Zombies: Replanted**.
This template provides a blank starting project to help you create a custom plugin quickly and easily.

**If you need help or want to be a part of the Plants vs Zombies: Replanted modding community, join our [Discord server](https://discord.gg/UfBMKTHN5b)!**

## Features

* Preconfigured plugin structure with necessary IL2CPP assembly references
* Example Plugin class with basic logging
* Ready-to-build .NET solution and project
* Available on NuGet: [`Replanted.PluginTemplate`](https://www.nuget.org/packages/Replanted.PluginTemplate)

## Requirements

* [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [BepInEx for Unity and IL2CPP](https://github.com/BepInEx/BepInEx)
* [Plants vs. Zombies: Replanted](https://store.steampowered.com/app/3654560/Plants_vs_Zombies_Replanted/)

## Getting Started

### 1. Install via NuGet

You can install this project teplate from NuGet:
```bash
dotnet new install Replanted.PluginTemplate
```
And then create a new project using Visual Studio or by running:

```bash
dotnet add package Replanted.PluginTemplate
```

### 2. Modify the Template

When you open the solution in your IDE (e.g. Visual Studio or Rider), the main sctructure should look something like this:

```csharp
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace ReplantedTemplate;

[BepInPlugin(Name, Name, Version)]
public class ReplantedTemplatePlugin : BasePlugin
{
    public const string Name = "ReplantedTemplate";
    public const string Version = "1.0.0";
    public const string Id = "com.yourname.plugin";

    public Harmony Harmony { get; } = new Harmony(Id);

    public static ManualLogSource Logger;

    public override void Load()
    {
        Logger = Log;
        Logger.LogInfo($"\"{Name}\" Plugin has been loaded.");

        Harmony.PatchAll();
    }
}
```
From here you can:
* Create your own custom classes that reference the game code (from the `Reloaded` namespace).
* Use tools like [HarmonyX](https://github.com/BepInEx/HarmonyX/wiki) to patch game methods.
* Log into the BepInEx console with the provided logger/

### 3. Build and Install

* Download and extract the `Unity.IL2CPP` version of [BepInEx](https://builds.bepinex.dev/projects/bepinex_be) into your PvZ: Replanted directory.
* Build the project to generate a `.dll` file in `bin/Debug/net6.0/`.
* Place the output `.dll` into your **BepInEx/plugins/** folder in the game directory.
* Launch the game. You should see the BepInEx console and your plugin should load.

> ⚠️ If the game reopens and the BepInEx console window disappears after launch, create a file called `steam_appid.txt` in your game directory and paste the following string inside: **3654560**

## Patching Methods
The plugin template comes with an example patch that demonstrates how to use HarmonyX to inject code:

```csharp
// Example Harmony Patch that changes any planted seed to a Marigold
[HarmonyPatch(typeof(Board), nameof(Board.AddPlant))]
internal static class PlantPlacedPatch
{
    internal static void Prefix(Board __instance, ref SeedType theSeedType)
    {
        ReplantedTemplatePlugin.Logger.LogInfo($"Changing planted seed from {theSeedType} to Marigold.");
        theSeedType = SeedType.Marigold;
    }
}
```
* `[HarmonyPatch(typeof(Board), nameof(Board.AddPlant))]` - This attribute defines what class (eg. Board) and the name of a method (eg. AddPlant) to patch.
* `internal static void Prefix` - The method name `Prefix` means this patch will execute before the actual method. You can use `Postfix` to run code after.
* `Board __instance, ref SeedType theSeedType` - Defining an `__instance` parameter provides access to the instance of the class. You can also include any parameters of the original method. In the case of the example, `theSeedType` is prefixed with the `ref` keyword to modify it before the plant is placed.
