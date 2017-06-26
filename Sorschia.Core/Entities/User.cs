using Sorschia.Entities;
using System;

namespace Sorschia.Core.Entities
{
    public class User : Entity<ulong>
    {
        public User()
        {
        }

        public User(Person owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public UserStatus Status { get; set; }
        public UserType Type { get; set; }
        public Person Owner { get; }
        public string DisplayName { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
