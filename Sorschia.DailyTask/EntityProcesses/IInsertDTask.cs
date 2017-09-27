using Sorschia.DailyTask.Entities;
using Sorschia.Processing;

namespace Sorschia.DailyTask.EntityProcesses
{
    public interface IInsertDTask : IProcess<IDTask>
    {
        IDTask DTask { get; set; }
    }
}
