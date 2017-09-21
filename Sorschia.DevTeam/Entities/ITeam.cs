using Sorschia.Entities;
using System;

namespace Sorschia.DevTeam.Entities
{
    public interface ITeam : IEntity<int>
    {
        string Name { get; set; }
        DateTime EstablishDate { get; set; }
        ITeamMemberCollection Members { get; }
    }
}
