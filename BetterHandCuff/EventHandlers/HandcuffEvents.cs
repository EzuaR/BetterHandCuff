using Exiled.Events.EventArgs.Player;

namespace BetterHandCuff.EventHandlers
{
    public class HandcuffEvents
    {

        public static void OnHandcuffingEvent(HandcuffingEventArgs ev) => ev.IsAllowed = Program.Instance.Config.NormalHandCuff;


        public static void OnRemovingHandcuffsEvent(RemovingHandcuffsEventArgs ev) => ev.IsAllowed = Program.Instance.Config.NormalHandCuff;

    }
}
