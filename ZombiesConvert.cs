﻿namespace ZombiesConvert
{
    using Exiled.API.Features;
    using Exiled.API.Enums;
    using Player = Exiled.Events.Handlers.Player;

    public class ZC : Plugin<Config>
    {
        public override string Name => "ZombiesConvert";
        public override string Prefix => "zombieconvert";
        public override string Author => "@misfiy";
        public override PluginPriority Priority => PluginPriority.Default;
        private PlayerHandler playerHandler;
        public static ZC Instance;
        private Config config;
        public override void OnEnabled()
        {
            Instance = this;
            config = Instance.Config;

            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            Instance = null!;
            base.OnDisabled();
        }
        public void RegisterEvents()
        {
            playerHandler = new PlayerHandler();
            Player.Dying += playerHandler.OnDying;

            Log.Debug("Events have been registered!");
        }
        public void UnregisterEvents()
        {
            Player.Dying -= playerHandler.OnDying;

            playerHandler = null!;
        }
    }
}