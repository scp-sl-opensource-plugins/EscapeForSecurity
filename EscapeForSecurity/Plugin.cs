using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;
using Respawning;

namespace EscapeForSecurity
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin plugin;
        public override string Prefix => "EscapeForSecurity";
        public override string Name => "EscapeForSecurity";
        public override string Author => "[OPENSOURCE PLUGIN] [https://github.com/scp-sl-opensource-plugins]";
        public override PluginPriority Priority => PluginPriority.Last;

        public override void OnEnabled()
        {
            plugin = this;
            Exiled.Events.Handlers.Player.Escaping += OnEscaping;
            base.OnEnabled();
        }

        private void OnEscaping(Exiled.Events.EventArgs.Player.EscapingEventArgs ev)
        {
            if (ev.Player.Role.Type is RoleTypeId.FacilityGuard && ev.IsAllowed)
            {
                ev.EscapeScenario = EscapeScenario.CustomEscape;
                ev.NewRole = ev.Player.IsCuffed ? Config.RoleAfterCuffedEscape : Config.RoleAfterEscape;
                RespawnTokensManager.RemoveTokens(ev.Player.IsCuffed ? SpawnableTeamType.NineTailedFox : SpawnableTeamType.ChaosInsurgency, Config.TicketsAfterEscapeCount);
            }
        }

        public override void OnDisabled()
        {
            plugin = null;
            Exiled.Events.Handlers.Player.Escaping -= OnEscaping;
            base.OnDisabled();
        }
    }
}