using Sorschia.Entity;
using System.Security;

namespace Sorschia.DevTeam.Entities
{
    public interface IUser : IEntity<long>
    {
        Member Owner { get; set; }
        SecureString SecureUsername { get; set; }
        SecureString SecurePassword { get; set; }
    }
}
