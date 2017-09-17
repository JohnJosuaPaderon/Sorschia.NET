using Sorschia.Entities;

namespace Sorschia.DevTeam.Entities
{
    public class Member : Entity<long>
    {
        public Member()
        {
            Teams = new TeamCollection();
        }

        public string Name { get; set; }
        public Role Role { get; set; }

        public IEntityCollection<Team, int> Teams { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
