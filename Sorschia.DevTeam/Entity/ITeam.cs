using Sorschia.Entity;
using System;

namespace Sorschia.DevTeam.Entity
{
    public interface ITeam : IEntity<int>
    {
        string Name { get; set; }
        DateTime EstablishDate { get; set; }
        ITeamMemberCollection Members { get; }
    }
}
