using Sorschia.Core.Entities;

namespace Sorschia.Core.EntityProcesses
{
    public interface IGetUserList : IEnumerableDataProcess<User>, IAsyncEnumerableDataProcess<User>, ICancellableEnumerableDataProcess<User>
    {
    }
}
