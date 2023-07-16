namespace ZombiesConvert
{
     using Exiled.API.Features;
     using Exiled.API.Enums;
     using ZombiesConvert.Events;
     using Player = Exiled.Events.Handlers.Player;

     public class ZC : Plugin<Config>
     {
          public override string Name => "BleedingPlugin";
          public override string Prefix => "Bleeding";
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
               Instance = null;
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

               playerHandler = null;
          }
     }
}

// player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Pink);