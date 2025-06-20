using BetterHandCuff.Configs;
using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using System;
using player = Exiled.Events.Handlers.Player;
using server = Exiled.Events.Handlers.Server;

namespace BetterHandCuff
{
    public class Program : Plugin<Config, Translation>
    {
        public static Program Instance;
        internal Harmony _harmony;
        public override string Author => "@ezuareal";
        public override string Name => "BetterHandCuff";
        public override string Prefix => "BetterHandCuff";
        public override Version Version { get; } = new(1, 3, 0);
        public override Version RequiredExiledVersion { get; } = new(9, 6, 1);
        public override PluginPriority Priority => PluginPriority.Higher;

        public override void OnEnabled()
        {
            Instance = this;

            server.RoundEnded += EventHandlers.EndedRoundEvent.OnEndRoundEvent;
            player.SpawnedRagdoll += EventHandlers.SpawnedRagdollEvent.OnSpawnedRagdollEvent;
            player.Verified += EventHandlers.VerifiedEvent.OnVerifiedEvent;
            player.Spawned += EventHandlers.PlayerSpawnedEvent.OnPlayerSpawnedEvent;
            player.Handcuffing += EventHandlers.HandcuffEvents.OnHandcuffingEvent;
            player.RemovingHandcuffs += EventHandlers.HandcuffEvents.OnRemovingHandcuffsEvent;

            _harmony = new Harmony($"ezuar.betterhandcuff.{DateTime.Now.Ticks}");
            _harmony.PatchAll();

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Instance = null;

            server.RoundEnded -= EventHandlers.EndedRoundEvent.OnEndRoundEvent;
            player.SpawnedRagdoll -= EventHandlers.SpawnedRagdollEvent.OnSpawnedRagdollEvent;
            player.Verified -= EventHandlers.VerifiedEvent.OnVerifiedEvent;
            player.Spawned -= EventHandlers.PlayerSpawnedEvent.OnPlayerSpawnedEvent;
            player.Handcuffing -= EventHandlers.HandcuffEvents.OnHandcuffingEvent;
            player.RemovingHandcuffs -= EventHandlers.HandcuffEvents.OnRemovingHandcuffsEvent;

            _harmony.UnpatchAll();

            base.OnDisabled();
        }


    }
}
