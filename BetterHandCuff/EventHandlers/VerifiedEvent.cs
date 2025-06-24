using BetterHandCuff.Dictionaries;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace BetterHandCuff.EventHandlers
{
    public class VerifiedEvent
    {
        public static void OnVerifiedEvent(VerifiedEventArgs ev)
        {
            Player player = ev.Player;

            HandCuffManager.RemoveAllHandCuffs(player);
        }
    }
}
