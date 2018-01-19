using Sorschia.Entity;

namespace Sorschia.DevTeam.Entity
{
    public interface ITeamMemberCollection : IEntityCollection<ITeamMember, long>
    {
        ITeam Team { get; }
    }
}
