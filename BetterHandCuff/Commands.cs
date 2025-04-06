using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace BetterHandCuff
{

    [CommandHandler(typeof(ClientCommandHandler))]
    public class Cuff : MonoBehaviour, ICommand
    {

        public string[] Aliases => Array.Empty<string>();

        public string Description => Program.Instance.Translation.CommandCuffDescription;

        public string Command => Program.Instance.Translation.CommandCuffName;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            RaycastHit Hit;

            Ray ray = new Ray(player.GameObject.transform.position, player.GameObject.transform.forward);

            response = "Something went wrong";

            if (player is null || player.GameObject == null)
                return false;

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

            GameObject GotHit = Hit.collider.transform.root.gameObject;

            Player playerhited = Player.Get(GotHit);

            if (playerhited is null)
            {
                response = "You can't cuff nobody";
                return false;

            }
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






    [CommandHandler(typeof(ClientCommandHandler))]
    public class Uncuff : MonoBehaviour, ICommand
    {

        public string[] Aliases => Array.Empty<string>();

        public string Description => Program.Instance.Translation.CommandUnCuffDescription;

        public string Command => Program.Instance.Translation.CommandUnCuffName;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            Player player = Player.Get(sender);

            RaycastHit Hit;

            Ray ray = new Ray(player.GameObject.transform.position, player.GameObject.transform.forward);

            response = "Something went wrong";



            if (player is null || player.GameObject == null)
                return false;

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

    [CommandHandler(typeof(ClientCommandHandler))]
    public class GetHandCuff : MonoBehaviour, ICommand
    {
        public string Command => Program.Instance.Translation.CommandLootName;

        public string[] Aliases => Array.Empty<string>();

        public string Description => Program.Instance.Translation.CommandLootDesc;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            Ragdoll closestRagdoll = null;
            response = "Something went wrong.";
            
            if (player is null)
                return false;

            int maxHandcuffs = Program.Instance.Config.MaxHandCuff;
            int playerHandcuffs = HandCuffManager.HowManyHandCuffs(player);

            if (playerHandcuffs >= maxHandcuffs)
            {
                response = "You have the maximum number of handcuffs.";
                return false;
            }

            int maxDistance = Program.Instance.Config.Distance;

            Vector3 closestRagdollPos = Vector3.zero;
            float closestDist = float.MaxValue;

            foreach (Ragdoll ragdoll in Ragdoll.List)
            {
                float dist = Vector3.Distance(player.Position, ragdoll.Position);
                if (dist < closestDist && dist <= maxDistance)
                {
                    closestRagdollPos = ragdoll.Position;
                    closestDist = dist;
                    closestRagdoll = ragdoll;
                }
            }

            if (closestRagdollPos == Vector3.zero)
            {
                response = "No ragdoll in range.";
                return false;
            }

            if (!DataSystem.GetPos(closestRagdoll))
            {
                response = "Ragdoll has no data.";
                return false;
            }

            int handcuffAmount = DataSystem.RagdollHandCuffAmount(closestRagdoll);
            if (handcuffAmount <= 0)
            {
                response = "Ragdoll doesn't have handcuffs.";
                return false;
            }

            System.Random rand = new System.Random();
            int maxDrop = (handcuffAmount == 1) ? 2 : handcuffAmount;
            int playerWillGet = rand.Next(1, maxDrop + 1);

            int before = HandCuffManager.HowManyHandCuffs(player);
            HandCuffManager.HandCuffAdd(player, playerWillGet);
            int after = HandCuffManager.HowManyHandCuffs(player);

            int difference = after - before;

            if (difference > 0)
            {
                DataSystem.RagdollRemoveHandCuff(closestRagdoll, difference);
                player.ShowHint($"{Program.Instance.Translation.BodyLooting} {difference} {Program.Instance.Translation.BodyLooting2}", Program.Instance.Config.Time);
                response = "You looted handcuffs from the body.";
                return true;
            }

            response = "No handcuffs were added.";
            return false;
        }



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

                    player.ShowHint($"{Program.Instance.Translation.HandCuffAmount}{HandCuffManager.HowManyHandCuffs(player)} {Program.Instance.Translation.HandCuffAmount2}", Program.Instance.Config.Time);


                }
                response = "Command executed successfully.";
                return true;


            }


        }


    }
}



