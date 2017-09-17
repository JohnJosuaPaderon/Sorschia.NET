using Sorschia.Entities;

namespace Sorschia.DevTeam.Entities
{
    public interface ITeamMemberCollection : IEntityCollection<TeamMember, long>
    {
        Team Team { get; }
    }
}
