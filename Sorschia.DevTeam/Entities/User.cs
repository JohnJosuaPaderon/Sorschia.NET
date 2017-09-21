using Sorschia.Entities;
using System.Security;

namespace Sorschia.DevTeam.Entities
{
    public class User : Entity<long>, IUser
    {
        public Member Owner { get; set; }
        public SecureString SecureUsername { get; set; }
        public SecureString SecurePassword { get; set; }
    }
}
