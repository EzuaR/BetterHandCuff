using HarmonyLib;
using LabApi.Features.Wrappers;
using PlayerRoles;

namespace BetterHandCuff.Patches
{
    [HarmonyPatch(typeof(PlayerRoles.HumanRole), nameof(PlayerRoles.HumanRole.AllowDisarming))]
    public static class PlayerCuffingPrefix
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result, ReferenceHub detainer)
        {
            if (Player.Get(detainer).Team.GetFaction() == Player.Get(detainer).Team.GetFaction())
            {
                __result = true;
                return false;
            }


            return true;
        }
    }
}
