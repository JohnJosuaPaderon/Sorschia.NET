using System;

namespace Sorschia.DevTeam.Entities
{
    public class TeamMember : Member, ITeamMember
    {
        public ITeam Team { get; set; }
        public DateTime? JoinDate { get; set; }
    }
}
