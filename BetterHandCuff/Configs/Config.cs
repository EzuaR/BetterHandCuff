using Exiled.API.Interfaces;
using PlayerRoles;
using System.Collections.Generic;
using System.ComponentModel;

namespace BetterHandCuff.Configs
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Debug doesn't work yet.")]
        public bool Debug { get; set; }
        [Description("Time of hints.")]
        public int Time { get; set; } = 4;
        [Description("Range of cuffing commands.")]
        public float Range { get; set; } = 10;
        [Description("Range of loot command.")]
        public int Distance { get; set; } = 5;
        [Description("max amount of handcuffs")]
        public int MaxHandCuff { get; set; } = 18;
        [Description("This classes will get a handcuff on start of the game.")]
        public HashSet<RoleTypeId> HandCuffOnStart { get; set; } = new() { RoleTypeId.ChaosMarauder, RoleTypeId.ChaosConscript, RoleTypeId.ChaosRifleman, RoleTypeId.ChaosRepressor, RoleTypeId.NtfCaptain, RoleTypeId.NtfPrivate, RoleTypeId.NtfSergeant, RoleTypeId.NtfSpecialist, RoleTypeId.FacilityGuard };
        [Description("How many handcuff player that is in HandCuffOnStart will get on spawn as that role.")]
        public int HowManyHandCuffAdd { get; set; } = 6;
        [Description("false if you want only to use plugin handcuffing system true if you also want both. ")]
        public bool NormalHandCuff { get; set; } = false;
        [Description("Allow Handcuffing people from the same team.")]
        public bool HandCuffPlayerFromTheSameTeam { get; set; } = true;
        [Description("Allows to have unlimited amount of handcuffs.")]
        public bool InfinityHandCuffs { get; set; } = false;
        
    }
}
