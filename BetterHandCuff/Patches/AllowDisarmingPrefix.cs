using HarmonyLib;
using LabApi.Features.Wrappers;
using PlayerRoles;

namespace BetterHandCuff.Patches
{
    [HarmonyPatch(typeof(PlayerRoles.HumanRole), nameof(PlayerRoles.HumanRole.AllowDisarming))]
    public static class AllowDisarmingPrefix
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result, ReferenceHub detainer)
        {
            if ( Program.Instance.Config.HandCuffPlayerFromTheSameTeam == true && Player.Get(detainer).Team.GetFaction() == Player.Get(detainer).Team.GetFaction())
            {
                __result = true;
                return false;
            }

            return true;
        }
    }
}
