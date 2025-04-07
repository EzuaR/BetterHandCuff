using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Threading.Tasks;

namespace BetterHandCuff.EventHandlers
{
    public class SpawnedRagdollEvent
    {
        public static void OnSpawnedRagdollEvent(SpawnedRagdollEventArgs ev)
        {
            _ = HandleRagdollSpawn(ev);
        }

        private static async Task HandleRagdollSpawn(SpawnedRagdollEventArgs ev)
        {
            Player player = ev.Player;
            int handcuffs = HandCuffManager.HowManyHandCuffs(player);

            Ragdoll ragdoll = ev.Ragdoll;


            await Task.Delay(2000);

            DataSystem.SaveData(ragdoll, handcuffs);
            HandCuffManager.RemoveAllHandCuffs(player);
        }
    }
}
