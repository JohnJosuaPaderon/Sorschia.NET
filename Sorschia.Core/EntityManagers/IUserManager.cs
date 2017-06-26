using Sorschia.Core.Entities;
using Sorschia.Entities;

namespace Sorschia.Core.EntityManagers
{
    public interface IUserManager : IEntityManager<User, ulong>
    {
    }

    public interface IAsyncUserManager : IAsyncEntityManager<User, ulong>
    {

    }

    public interface ICancellableAsyncUserManager : ICancellableAsyncEntityManager<User, ulong>
    {

    }
}
