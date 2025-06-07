using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;

namespace Scp3114AutoFF
{
    public class Scp3114AutoFF : Plugin<Config>
    {
        internal int Scp3114Count { get; set; } = 0;

        public override void OnEnabled()
        {
            PlayerEvents.ChangingRole += OnChangingRole;
            ServerEvents.RoundStarted += OnRoundStarted;
        }

        public override void OnDisabled()
        {
            PlayerEvents.ChangingRole -= OnChangingRole;
            ServerEvents.RoundStarted -= OnRoundStarted;
        }

        internal void OnChangingRole(ChangingRoleEventArgs args)
        {
            if (args.NewRole == PlayerRoles.RoleTypeId.Scp3114)
            {
                Log.Debug("SCP-3114 as NewRole detected, current count : " + Scp3114Count + ".");
                Server.FriendlyFire = true;
                Scp3114Count += 1;
            }
            else if (args.Player.Role == PlayerRoles.RoleTypeId.Scp3114)
            {
                Log.Debug("SCP-3114 as OldRole detected, current count : " + Scp3114Count + ".");
                Scp3114Count -= 1;
                if (Scp3114Count <= 0)
                {
                    Log.Debug("Last SCP-3114 has left, disabling friendly fire.");
                    Server.FriendlyFire = false;
                }
            }
        }

        internal void OnRoundStarted()
        {
            Log.Debug("Round started, resetting SCP-3114 count.");
            Scp3114Count = 0;
            Server.FriendlyFire = false;
        }
    }
}
