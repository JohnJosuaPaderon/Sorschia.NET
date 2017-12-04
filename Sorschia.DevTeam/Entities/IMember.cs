using Sorschia.Entity;

namespace Sorschia.DevTeam.Entities
{
    public interface IMember : IEntity<long>
    {
        string Name { get; set; }
        Role Role { get; }
        ITeamCollection Teams { get; }
    }
}
