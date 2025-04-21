using CommandSystem;
using Exiled.API.Features;
using System;

namespace BetterHandCuff.Commands.Client
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Givehandcuffs : ICommand
    {
        public string Command => throw new NotImplementedException();

        public string[] Aliases => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = "test";
                return false;
            }

            response = "tests";
            return false;
        }
    }
}
