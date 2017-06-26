using Sorschia.Core.Entities;

namespace Sorschia.Core.EntityProcesses
{
    public interface IUpdateUser : IDataProcess<User>, IAsyncDataProcess<User>, ICancellableAsyncDataProcess<User>
    {
        User User { get; set; }
    }
}
