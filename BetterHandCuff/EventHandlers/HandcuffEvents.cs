using Exiled.Events.EventArgs.Player;

namespace BetterHandCuff.EventHandlers
{
    public class HandcuffEvents
    {

        public static void OnHandcuffingEvent(HandcuffingEventArgs ev)
        {
            ev.IsAllowed = Program.Instance.Config.NormalHandCuff;

            if (ev.Target.Role.Team == ev.Player.Role.Team)
            {
                ev.IsAllowed = Program.Instance.Config.HandCuffPlayerFromTheSameTeam;
            }



        } 

        public static void OnRemovingHandcuffsEvent(RemovingHandcuffsEventArgs ev) => ev.IsAllowed = Program.Instance.Config.NormalHandCuff;

    }
}
