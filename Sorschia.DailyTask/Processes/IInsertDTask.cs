using Sorschia.DailyTask.Entity;
using Sorschia.Processing;

namespace Sorschia.DailyTask.Processes
{
    public interface IInsertDTask : IProcess<IDTask>
    {
        IDTask DTask { get; set; }
    }
}
