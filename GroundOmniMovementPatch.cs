using HarmonyLib;
using Pigeon.Movement;

[HarmonyPatch]
public static class GroundOmniMovementPatch
{
    private const float OmniMultiplier = 1f;

    [HarmonyPatch(typeof(Player), "Awake")]
    [HarmonyPostfix]
    private static void AwakePostfix(Player __instance)
    {
        ApplyOmniMultipliers(__instance);
    }


    [HarmonyPatch(typeof(Player), "Movement")]
    [HarmonyPrefix]
    private static void MovementPrefix(Player __instance)
    {
        ApplyOmniMultipliers(__instance);
    }

    private static void ApplyOmniMultipliers(Player player)
    {
        if (!ConfigManager.EnableOmniMovement.Value)
            return;

        player.strafeSpeedMultiplier = OmniMultiplier;
        player.strafeSpeedMultiplierWhileMoving = OmniMultiplier;
        player.backwardSpeedMultiplier = OmniMultiplier;
        player.slideStrafeMultiplier = OmniMultiplier;
    }
}