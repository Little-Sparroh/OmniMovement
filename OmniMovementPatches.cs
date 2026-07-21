using HarmonyLib;
using Pigeon.Movement;

/// <summary>
/// Vanilla movement normalizes input, then scales axes before building direction:
///   - strafeSpeedMultiplier / strafeSpeedMultiplierWhileMoving (default 0.77) when not sprinting
///   - backwardSpeedMultiplier (default 0.5)
///   - slideStrafeMultiplier (default 0.8) while sliding
/// Direction is not re-normalized, so those scales reduce actual speed.
/// Setting all multipliers to 1 yields consistent speed in every horizontal direction.
/// </summary>
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

    // Re-apply each movement tick so upgrades/resets cannot restore anisotropic speed.
    [HarmonyPatch(typeof(Player), "Movement")]
    [HarmonyPrefix]
    private static void MovementPrefix(Player __instance)
    {
        ApplyOmniMultipliers(__instance);
    }

    private static void ApplyOmniMultipliers(Player player)
    {
        if (!SparrohPlugin.enableOmniMovement.Value)
            return;

        player.strafeSpeedMultiplier = OmniMultiplier;
        player.strafeSpeedMultiplierWhileMoving = OmniMultiplier;
        player.backwardSpeedMultiplier = OmniMultiplier;
        player.slideStrafeMultiplier = OmniMultiplier;
    }
}
