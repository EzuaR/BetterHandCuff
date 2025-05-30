﻿
using BetterHandCuff.Dictionaries;
using CommandSystem;
using Exiled.API.Features;
using System;
using UnityEngine;

namespace BetterHandCuff.Commands.Client
{

    [CommandHandler(typeof(ClientCommandHandler))]
    public class Cuff : ICommand
    {

        public string[] Aliases => Array.Empty<string>();

        public string Description => Program.Instance.Translation.CommandCuffDescription;

        public string Command => Program.Instance.Translation.CommandCuffName;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            RaycastHit Hit;

            Ray ray = new Ray(player.GameObject.transform.position, player.GameObject.transform.forward);



            if (player is null || player.GameObject == null)
            {
                response = "Something went wrong";
                return false;
            }
            if (player.IsScp == true)
            {
                response = "Can't cuff players as SCP!";
                return false;
            }


            if (HandCuffManager.HowManyHandCuffs(player) is 0)
            {
                response = "You have 0 Handcuffs";
                return false;

            }


            if (!Physics.Raycast(ray, out Hit, Program.Instance.Config.Range))
            {

                response = "Nothing found.";
                return false;

            }

            if (player.IsCuffed == true)
            {
                response = "You cant use this command if you are cuffed.";
                return false;
            }

            GameObject GotHit = Hit.collider.transform.root.gameObject;

            Player playerhited = Player.Get(GotHit);


            if (playerhited is not null)
            {
                playerhited.Handcuff(player);
                player.ShowHint(Program.Instance.Translation.CuffHint, Program.Instance.Config.Time);
                HandCuffManager.RemoveHandCuffs(player, 1);



            }

            if (playerhited == player)
            {
                response = "You can't handcuff yourself!";
                return false;
            }




            response = "Command executed successfully";
            return true;

        }
    }
}
