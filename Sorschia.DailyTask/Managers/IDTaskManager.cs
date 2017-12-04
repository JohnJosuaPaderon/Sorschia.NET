using Sorschia.DailyTask.Entity;
using Sorschia.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.Managers
{
    public interface IDTaskManager
    {
        IProcessResult<IDTask> Delete(IDTask dTask);
        Task<IProcessResult<IDTask>> DeleteAsync(IDTask dTask);
        Task<IProcessResult<IDTask>> DeleteAsync(IDTask dTask, CancellationToken cancellationToken);
        IProcessResult<IDTask> GetById(long dTaskId);
        Task<IProcessResult<IDTask>> GetByIdAsync(long dTaskId);
        Task<IProcessResult<IDTask>> GetByIdAsync(long dTaskId, CancellationToken cancellationToken);
        IEnumerableProcessResult<IDTask> GetList();
        Task<IEnumerableProcessResult<IDTask>> GetListAsync();
        Task<IEnumerableProcessResult<IDTask>> GetListAsync(CancellationToken cancellationToken);
        IProcessResult<IDTask> Insert(IDTask dTask);
        Task<IProcessResult<IDTask>> InsertAsync(IDTask dTask);
        Task<IProcessResult<IDTask>> InsertAsync(IDTask dTask, CancellationToken cancellationToken);
        IProcessResult<IDTask> UpdateStatus(IDTask dTask);
        Task<IProcessResult<IDTask>> UpdateStatusAsync(IDTask dTask);
        Task<IProcessResult<IDTask>> UpdateStatusAsync(IDTask dTask, CancellationToken cancellationToken);
    }
}
