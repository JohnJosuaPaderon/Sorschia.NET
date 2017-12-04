using Sorschia.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.Entity.Manager
{
    public interface IDTaskManager
    {
        IProcessResult<IDTask> Insert(IDTask dTask);
        Task<IProcessResult<IDTask>> InsertAsync(IDTask dTask);
        Task<IProcessResult<IDTask>> InsertAsync(IDTask dTask, CancellationToken cancellationToken);
    }
}
