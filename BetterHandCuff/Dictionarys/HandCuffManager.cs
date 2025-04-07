using Exiled.API.Features;
using System.Collections.Generic;
namespace BetterHandCuff
{
    public static class HandCuffManager
    {
        private static Dictionary<string, int> PlayerHandCuff = new Dictionary<string, int>();

        public static void HandCuffAdd(Player player, int Amount)
        {
            string UserID = player.UserId;

            if (PlayerHandCuff.ContainsKey(UserID))
            {
                PlayerHandCuff[UserID] += Amount;
            }

        }



        public static void RemoveHandCuffs(Player player, int amount)
        {
            PlayerHandCuff[player.UserId] -= amount;
        }

        public static int HowManyHandCuffs(Player player)
        {
            return PlayerHandCuff.TryGetValue(player.UserId, out int HandCuffs) ? HandCuffs : 0;
        }

        public static void RemovePlayerFromDictionary(Player player)
        {
            PlayerHandCuff.Remove(player.UserId);

        }
        public static void RemoveAllHandCuffs(Player player) // also used to add player to Dictionary.
        {
            PlayerHandCuff[player.UserId] = 0;
        }

    }
}
