using Sorschia.Entities;

namespace Sorschia.DevTeam.Entities
{
    public interface ITeamMemberCollection : IEntityCollection<ITeamMember, long>
    {
        ITeam Team { get; }
    }
}
