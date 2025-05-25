using CommandSystem.Commands.RemoteAdmin.Dms;
using Exiled.API.Interfaces;
using PlayerRoles;
using System.Collections.Generic;
using System.ComponentModel;

namespace BetterHandCuff
{
    public class Config : IConfig
    {

        public bool IsEnabled { get; set; } = true;
        [Description("Debug doesn't work yet.")]
        public bool Debug { get; set; }

        public int Time { get; set; } = 4;

        public float Range { get; set; } = 10;

        public int Distance { get; set; } = 2;

        public int MaxHandCuff { get; set; } = 8;
        [Description("This class will get a handcuff on start of the game")]

        public HashSet<RoleTypeId> HandCuffOnStart { get; set; } = new() { RoleTypeId.ChaosMarauder, RoleTypeId.ChaosConscript, RoleTypeId.ChaosRifleman, RoleTypeId.ChaosRepressor, RoleTypeId.NtfCaptain, RoleTypeId.NtfPrivate, RoleTypeId.NtfSergeant, RoleTypeId.NtfSpecialist, RoleTypeId.FacilityGuard };

        [Description("How many handcuff player that is in HandCuffOnStart will get on spawn as that role.")]

        public int HowManyHandCuffAdd { get; set; } = 2;
        [Description("false if you want only to use plugin handcuffing system true if you also want both. ")]

        public bool NormalHandCuff { get; set; } = false;

        public bool HandCuffPlayerFromTheSameTeam { get; set; } = true;

        

    }
}
