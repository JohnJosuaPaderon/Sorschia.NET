using Sorschia.Entities;
using System;

namespace Sorschia.DevTeam.Entities
{
    public class Team : Entity<int>
    {
        public Team()
        {
            Members = new TeamMemberCollection(this);
        }

        public string Name { get; set; }
        public DateTime EstablishDate { get; set; }

        public IEntityCollection<TeamMember, long> Members { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
