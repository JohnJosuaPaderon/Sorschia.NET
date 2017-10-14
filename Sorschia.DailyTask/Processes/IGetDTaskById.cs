using Sorschia.DailyTask.Entities;
using Sorschia.Processing;

namespace Sorschia.DailyTask.Processes
{
    public interface IGetDTaskById : IProcess<IDTask>
    {
        long DTaskId { get; set; }
    }
}
