using BetterHandCuff.Dictionaries;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using Player = Exiled.API.Features.Player;

namespace BetterHandCuff.EventHandlers
{
    public class EndedRoundEvent
    {

        public static void OnEndRoundEvent(RoundEndedEventArgs ev)
        {
            
            foreach (Player player in Player.List)
            {
                HandCuffManager.RemovePlayerFromDictionary(player);
            }

            foreach (Ragdoll ragdoll in Ragdoll.List)
            {
                DataSystem.RemoveData(ragdoll);
            }

        }
    }
}
