using BetterHandCuff.Dictionaries;
using CommandSystem;
using Exiled.API.Features;
using System;
using UnityEngine;

namespace BetterHandCuff.Commands.Client
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class GetHandCuff : ICommand
    {
        public string Command => Program.Instance.Translation.CommandLootName;

        public string[] Aliases => Array.Empty<string>();

        public string Description => Program.Instance.Translation.CommandLootDesc;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            Ragdoll closestRagdoll = null;

            if (player.IsCuffed == true)
            {
                response = "You cant use this command if you are cuffed.";
                return false;
            }

            if (player is null)
            {
                response = "something went wrong.";
                return false;
            }

            if (player.IsScp == true)
            {
                response = "You can't use get handcuffs as scp!";
                return false;
            }


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
                player.ShowHint(string.Format(Program.Instance.Translation.BodyLooting, difference), Program.Instance.Config.Time);
                response = "You looted handcuffs from the body.";
                return true;
            }

            response = "No handcuffs were added.";
            return false;
        }

    }
}
