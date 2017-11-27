﻿using Sorschia.Entities;
using System;

namespace Sorschia.DevTeam.Entities
{
    public class Team : EntityBase<int>, ITeam
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
