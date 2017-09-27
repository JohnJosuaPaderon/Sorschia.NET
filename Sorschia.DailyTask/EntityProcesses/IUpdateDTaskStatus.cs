using Sorschia.DailyTask.Entities;
using Sorschia.Processing;

namespace Sorschia.DailyTask.EntityProcesses
{
    public interface IUpdateDTaskStatus : IProcess<IDTask>
    {
        IDTask DTask { get; set; }
    }
}
