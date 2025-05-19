using Exiled.API.Features;
using System;
using player = Exiled.Events.Handlers.Player;
using server = Exiled.Events.Handlers.Server;

namespace BetterHandCuff
{
    public class Program : Plugin<Config, Translation>
    {
        public static Program Instance;

        public override string Author => "Ezua";
        public override string Name => "BetterHandCuff";
        public override string Prefix => "BetterHandCuff";

        public override Version Version { get; } = new(1, 2, 0, 0);
        public override Version RequiredExiledVersion { get; } = new(9, 6, 0, 0);

        public override void OnEnabled()
        {
            Instance = this;

            server.RoundEnded += EventHandlers.EndedRoundEvent.OnEndRoundEvent;
            player.SpawnedRagdoll += EventHandlers.SpawnedRagdollEvent.OnSpawnedRagdollEvent;
            player.Verified += EventHandlers.VerifiedEvent.OnVerifiedEvent;
            player.Spawned += EventHandlers.PlayerSpawnedEvent.OnPlayerSpawnedEvent;
            player.Handcuffing += EventHandlers.HandcuffEvents.OnHandcuffingEvent;
            player.RemovingHandcuffs += EventHandlers.HandcuffEvents.OnRemovingHandcuffsEvent;

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

            base.OnDisabled();
        }

    }
}
