using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterHandCuff.Commands.RemoteAdmin
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class RemoveHandcuffsFromAll : ICommand
    {
        public string Command => "RemoveHandcuffsFromAllPlayers";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = "No player";
                return false;
            }

            foreach (Player player1 in Player.List)
            {
                HandCuffManager.RemoveAllHandCuffs(player1);
               
            }
            response = "Succes.";
            return true;
           
        }
    }
}
