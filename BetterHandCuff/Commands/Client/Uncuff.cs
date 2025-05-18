
using CommandSystem;
using Exiled.API.Features;
using InventorySystem.Items.Firearms.Modules;
using System;
using UnityEngine;

namespace BetterHandCuff.Commands.Client
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Uncuff : ICommand
    {

        public string[] Aliases => Array.Empty<string>();

        public string Description => Program.Instance.Translation.CommandUnCuffDescription;

        public string Command => Program.Instance.Translation.CommandUnCuffName;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            Player player = Player.Get(sender);

            RaycastHit Hit;

            Ray ray = new Ray(player.GameObject.transform.position, player.GameObject.transform.forward);
            


            if (player.IsCuffed == true)
            {
                response = "You cant use this command if you are cuffed.";
                return false;
            }
            
            
            if (player.IsCuffed == false)
            {
                response = "Player isn't cuffed.";
                return false;
            }


            if (player is null || player.GameObject == null)
            {
                response = "Something went wrong";
                return false;
            }


            if (player.IsScp == true)
            {
                response = "You can't use handcuffs as scp!";
                return false;
            }

            if (!Physics.Raycast(ray, out Hit, Program.Instance.Config.Range))
            {

                response = "Nothing found.";
                return false;
            }
           



            GameObject GotHit = Hit.collider.transform.root.gameObject;

            Player playerhited = Player.Get(GotHit);


            if (playerhited is null)
            {
                response = "You can't Uncuff nobody";
                return false;
            }




            if (playerhited is not null)
            {
                playerhited.RemoveHandcuffs();
                player.ShowHint(Program.Instance.Translation.UnCuffHint, Program.Instance.Config.Time);
                HandCuffManager.HandCuffAdd(player, 1);

            }

            if (playerhited == player)
            {
                response = "You can't Uncuff yourself!";
                return false;
            }


            response = "Command executed successfully.";
            return true;
        }

    }
}
