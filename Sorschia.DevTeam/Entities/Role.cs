using Sorschia.Entities;

namespace Sorschia.DevTeam.Entities
{
    public class Role : Entity<int>
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
