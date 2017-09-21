using Sorschia.Entities;
using System;

namespace Sorschia.DevTeam.Entities
{
    public class Team : Entity<int>, ITeam
    {
        public Team()
        {
            Members = new TeamMemberCollection(this);
        }

        public string Name { get; set; }
        public DateTime EstablishDate { get; set; }

        public ITeamMemberCollection Members { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
