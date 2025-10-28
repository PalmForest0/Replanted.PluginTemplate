using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace ReplantedTemplate;

[BepInPlugin(Name, Name, Version)]
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