using Sorschia.Entity;

namespace Sorschia.DevTeam.Entity
{
    public interface IMember : IEntity<long>
    {
        string Name { get; set; }
        Role Role { get; }
        ITeamCollection Teams { get; }
    }
}
