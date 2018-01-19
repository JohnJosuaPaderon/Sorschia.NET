using Sorschia.Entity;
using System;

namespace Sorschia.DevTeam.Entity
{
    public interface ITeamMember : IMember, IEntity<long>
    {
        ITeam Team { get; set; }
        DateTime? JoinDate { get; set; }
    }
}
