using Sorschia.Entities;
using System;

namespace Sorschia.DevTeam.Entities
{
    public interface ITeamMember : IMember, IEntity<long>
    {
        ITeam Team { get; set; }
        DateTime? JoinDate { get; set; }
    }
}
