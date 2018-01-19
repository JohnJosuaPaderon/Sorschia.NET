using System;

namespace Sorschia.DevTeam.Entity
{
    public class TeamMember : Member, ITeamMember
    {
        public ITeam Team { get; set; }
        public DateTime? JoinDate { get; set; }
    }
}
