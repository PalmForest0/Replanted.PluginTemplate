using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Reloaded.Gameplay;

namespace ReplantedTemplate;

[BepInPlugin(Name, Name, Version)]
[BepInProcess("Replanted.exe")]
public class ReplantedTemplatePlugin : BasePlugin
{
    public const string Name = "ReplantedTemplate";
    public const string Version = "PluginVersion";
    public const string Id = "PluginId";

    public Harmony Harmony { get; } = new Harmony(Id);

    public static ManualLogSource Logger;

    public override void Load()
    {
        Logger = Log;
        Logger.LogInfo($"\"{Name}\" Plugin has been loaded.");

        Harmony.PatchAll();
    }
}

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