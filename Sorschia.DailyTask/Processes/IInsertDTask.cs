using Sorschia.DailyTask.Entities;
using Sorschia.Processing;

namespace Sorschia.DailyTask.Processes
{
    public interface IInsertDTask : IProcess<IDTask>
    {
        IDTask DTask { get; set; }
    }
}
