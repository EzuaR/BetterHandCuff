using Exiled.Events.EventArgs.Player;


namespace BetterHandCuff.EventHandlers
{
    public class HandcuffingEvent
    {
        
        public static void OnHandcuffingEvent(HandcuffingEventArgs ev)
        {
            if (Program.Instance.Config.NormalHandCuff == false)
            {
                ev.IsAllowed = false;
            }
            else if (Program.Instance.Config.NormalHandCuff == true)
            {
                ev.IsAllowed = true;
            }
            
        }
    }
}
