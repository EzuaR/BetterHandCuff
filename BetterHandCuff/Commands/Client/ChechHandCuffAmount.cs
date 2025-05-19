using BetterHandCuff.Dictionaries;
using CommandSystem;
using Exiled.API.Features;
using System;

namespace BetterHandCuff.Commands.Client
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ChechHandCuffAmount : ICommand
    {

        public string Command => Program.Instance.Translation.CommandCheckHandCuffAmountName;

        public string[] Aliases => Array.Empty<string>();

        public string Description => Program.Instance.Translation.CommandCheckHandCuffAmountDesc;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);


            if (player.IsScp == true)
            {
                response = "You don't have handcuff as scp!";
                return false;
            }
            if (player is not null)
            {
                player.ShowHint(string.Format(Program.Instance.Translation.HandCuffAmount, HandCuffManager.HowManyHandCuffs(player)), Program.Instance.Config.Time);
            }

            response = "Command executed successfully.";
            return true;

        }

    }

}

