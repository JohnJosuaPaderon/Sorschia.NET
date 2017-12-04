using Sorschia.DailyTask.Entity;
using Sorschia.Processing;

namespace Sorschia.DailyTask.Processes
{
    public interface IGetDTaskById : IProcess<IDTask>
    {
        long DTaskId { get; set; }
    }
}
