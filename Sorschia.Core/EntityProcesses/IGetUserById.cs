using Sorschia.Core.Entities;

namespace Sorschia.Core.EntityProcesses
{
    public interface IGetUserById : IDataProcess<User>, IAsyncDataProcess<User>, ICancellableAsyncDataProcess<User>
    {
        ulong UserId { get; set; }
    }
}
