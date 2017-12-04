using Sorschia.Entity;

namespace Sorschia.DevTeam.Entities
{
    public class Member : EntityBase<long>, IMember
    {
        public Member()
        {
            Teams = new TeamCollection();
        }

        public string Name { get; set; }
        public Role Role { get; set; }
        public ITeamCollection Teams { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
