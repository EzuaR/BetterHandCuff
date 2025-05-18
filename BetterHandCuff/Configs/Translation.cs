using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BetterHandCuff
{
    public class Translation : ITranslation
    {
        [Description("Command names")]
        public string CommandCuffName { get; set; } = "Cuff";
        public string CommandUnCuffName { get; set; } = "Uncuff";
        public string CommandLootName { get; set; } = "loot";
        public string CommandCheckHandCuffAmountName { get; set; } = "CheckAmount";
        public string CommandHandCuffSelfName { get; set; } = "CuffYourself";
        [Description("Command descriptions")]
        public string CommandCuffDescription { get; set; } = "Cuffs the player.";
        public string CommandUnCuffDescription { get; set; } = "Uncuffs the player.";
        public string CommandCheckHandCuffAmountDesc { get; set; } = "Checks the number of handcuffs a player has.";
        public string CommandLootDesc { get; set; } = "Just approach the body and enter the command. This will give you a random number of handcuffs that body has on it.";
        public string CommandHandCuffSelfDesc { set; get; } = "Use it if you want to handcuff yourself";

       [Description("Hints content")]
        public string CuffHint { get; set; } = "You cuffed the player.";
        public string UnCuffHint { get; set; } = "You uncuffed the player.";
        [Description("In this case you need to make something like: 'HandCuffAmount (number) HandCuffAmount2 or just HandCuffAmount (number) and set HandCuffAmount2 to blank' ")]
        public string HandCuffAmount { get; set; } = "You have {0} handcuffs. ";
        public string BodyLooting { get; set; } = "You have acquired {0} handcuffs. ";

    }
}
