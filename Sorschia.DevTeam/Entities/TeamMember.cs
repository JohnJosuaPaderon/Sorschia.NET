using System;

namespace Sorschia.DevTeam.Entities
{
    public class TeamMember : Member
    {
        public Team Team { get; set; }
        public DateTime? JoinDate { get; set; }
    }
}
