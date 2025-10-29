# PvZ: Replanted BepInEx Plugin Template

[![NuGet Version](https://img.shields.io/nuget/v/Replanted.PluginTemplate.svg?style=for-the-badge&color=brightgreen)](https://www.nuget.org/packages/Replanted.PluginTemplate)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Replanted.PluginTemplate.svg?style=for-the-badge&color=blue)](https://www.nuget.org/packages/Replanted.PluginTemplate)

A simple [BepInEx](https://github.com/BepInEx/BepInEx) plugin template for modding **Plants vs Zombies: Replanted**.
This template provides a blank starting project to help you create a custom plugin quickly and easily.

## Features

* Preconfigured plugin structure with necessary IL2CPP assembly references
* Example Plugin class with basic logging
* Ready-to-build .NET solution and project
* Available on NuGet: [`Replanted.PluginTemplate`](https://www.nuget.org/packages/Replanted.PluginTemplate)

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

* Open the project in your IDE (e.g. Visual Studio or Rider).
* Use tools like [HarmonyX](https://github.com/BepInEx/HarmonyX/wiki) to patch game methods.

### 3. Build and Install

* Download and extract the `Unity.IL2CPP` version of [BepInEx](https://builds.bepinex.dev/projects/bepinex_be) into your PvZ: Replanted directory.
* Build the project to generate a `.dll` file in `bin/Debug/net6.0/`.
* Place the output `.dll` into your **BepInEx/plugins/** folder in the game directory.
* Launch the game. You should see the BepInEx console and your plugin should load.

> ⚠️ If the game reopens and the BepInEx console window disappears after launch, create a file called `steam_appid.txt` in your game directory and paste the following string inside: **3654560**

## Requirements

* [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [BepInEx for Unity and IL2CPP](https://github.com/BepInEx/BepInEx)
* [Plants vs. Zombies: Replanted](https://store.steampowered.com/app/3654560/Plants_vs_Zombies_Replanted/)
