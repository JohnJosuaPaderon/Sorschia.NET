using Sorschia.Core.Entities;

namespace Sorschia.Core.EntityProcesses
{
    public interface IInsertUser : IDataProcess<User>, IAsyncDataProcess<User>, ICancellableAsyncDataProcess<User>
    {
        User User { get; set; }
    }
}
