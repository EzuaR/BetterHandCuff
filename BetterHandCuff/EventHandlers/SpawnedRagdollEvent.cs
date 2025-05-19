using BetterHandCuff.Dictionaries;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BetterHandCuff.EventHandlers
{
    public class SpawnedRagdollEvent
    {
        public static void OnSpawnedRagdollEvent(SpawnedRagdollEventArgs ev)
        {
            Timing.CallDelayed(2f, () => HandleRagdollSpawn(ev));
        }

        private static void HandleRagdollSpawn(SpawnedRagdollEventArgs ev)
        {
            Player player = ev.Player;
            int handcuffs = HandCuffManager.HowManyHandCuffs(player);

            Ragdoll ragdoll = ev.Ragdoll;

            DataSystem.SaveData(ragdoll, handcuffs);
            HandCuffManager.RemoveAllHandCuffs(player);
        }
    }
}
