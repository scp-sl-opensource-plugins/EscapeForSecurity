using Exiled.API.Interfaces;
using PlayerRoles;

namespace EscapeForSecurity
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        public RoleTypeId RoleAfterEscape { get; set; } = RoleTypeId.NtfSergeant;
        public RoleTypeId RoleAfterCuffedEscape { get; set; } = RoleTypeId.ChaosMarauder;
        public float TicketsAfterEscapeCount { get; set; } = 10;
    }
}