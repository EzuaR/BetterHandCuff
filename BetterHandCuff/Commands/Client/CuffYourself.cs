using BetterHandCuff.Dictionaries;
using CommandSystem;
using Exiled.API.Features;
using MEC;
using System;

namespace BetterHandCuff.Commands.Client
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class CuffYourself : ICommand
    {
        public string Command => Program.Instance.Translation.CommandHandCuffSelfName;

        public string[] Aliases => Array.Empty<string>();

        public string Description => Program.Instance.Translation.CommandHandCuffSelfDesc;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);


            if (player.IsCuffed == true)
            {
                response = "You cant use this command if you are cuffed.";
                return false;
            }

            if (player.IsScp == true)
            {
                response = "You can't cuff yourself as SCP!";
                return false;
            }
            int Amount = HandCuffManager.HowManyHandCuffs(player);
            if (Amount == 0)
            {
                response = "You have 0 handcuffs. Can't Handcuff yourself.";
                return false;
            }
            if (player is not null)
            {
                player.DropItems();
                Timing.CallDelayed(1f, () =>
                {
                    player.Handcuff(player);
                    HandCuffManager.RemoveHandCuffs(player, 1);

                });
                response = "Command executed successfully.";
                return true;
            }

            response = "Something went wrong.";
            return false;
        }
    }
}
