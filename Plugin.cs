using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
[MycoMod(null, ModFlags.IsClientSide)]
public class SparrohPlugin : BaseUnityPlugin
{
    public const string PluginGUID = "sparroh.omnimovement";
    public const string PluginName = "OmniMovement";
    public const string PluginVersion = "2.0.0";

    internal static new ManualLogSource Logger;
    internal static ConfigEntry<bool> enableOmniMovement;

    private Harmony harmony;

    private void Awake()
    {
        Logger = base.Logger;

        enableOmniMovement = Config.Bind(
            "General",
            "Enable Omni Movement",
            true,
            "Makes ground movement speed consistent in all directions (forward, strafe, backward, diagonals, and slide strafe).");

        harmony = new Harmony(PluginGUID);
        harmony.PatchAll(typeof(GroundOmniMovementPatch));

        Logger.LogInfo($"{PluginName} v{PluginVersion} loaded successfully.");
    }

    private void OnDestroy()
    {
        harmony?.UnpatchSelf();
    }
}
