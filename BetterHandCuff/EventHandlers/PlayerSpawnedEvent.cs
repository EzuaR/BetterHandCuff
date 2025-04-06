using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace BetterHandCuff.EventHandlers
{
    public class PlayerSpawnedEvent
    {
        public static void OnPlayerSpawnedEvent(SpawnedEventArgs ev)
        {
            Player player = ev.Player;

            if (Program.Instance.Config.HandCuffOnStart.Contains(player.Role))
            {
                HandCuffManager.HandCuffAdd(player, Program.Instance.Config.HowManyHandCuffAdd);
            }
        }
    }
}
