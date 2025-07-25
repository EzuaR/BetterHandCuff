﻿using BetterHandCuff.Dictionaries;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

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
            if (Program.Instance.Config.InfinityHandCuffs == false)
            {
                Player player = ev.Player;
                int handcuffs = HandCuffManager.HowManyHandCuffs(player);

                Ragdoll ragdoll = ev.Ragdoll;

                DataSystem.SaveData(ragdoll, handcuffs);
                HandCuffManager.RemoveAllHandCuffs(player);
            }
        }
    }
}
