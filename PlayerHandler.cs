namespace ZombiesConvert
{
    using Exiled.Events.EventArgs.Player;
    using PlayerRoles;
    using Exiled.API.Enums;
    using MEC;
    public sealed class PlayerHandler
    {
        private readonly Random rand = new();
        public void OnDying(DyingEventArgs ev)
        {
            if (ev.Attacker != null && ev.Attacker.Role.Type == RoleTypeId.Scp0492)
            {
                if (rand.Next(1, 101) <= ZC.Instance.Config.Chance)
                    Timing.CallDelayed(0.2f, () =>
                    {
                        ev.Player.Role.Set(RoleTypeId.Scp0492, SpawnReason.Revived);
                        ev.Player.Health = ev.Player.MaxHealth;
                        ev.Player.DropItems();
                    });
            }
        }
    }
}