using Sorschia.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Manager
{
    public interface IAssignmentStatusManager
    {
        IProcessResult<IAssignmentStatus> Get(short id);
        Task<IProcessResult<IAssignmentStatus>> GetAsync(short id);
        Task<IProcessResult<IAssignmentStatus>> GetAsync(short id, CancellationToken cancellationToken);
        IProcessResult<IAssignmentStatus> GetByKey(string key);
        Task<IProcessResult<IAssignmentStatus>> GetByKeyAsync(string key);
        Task<IProcessResult<IAssignmentStatus>> GetByKeyAsync(string key, CancellationToken cancellationToken);
    }
}
