using Sorschia.DailyTask.Entities;
using Sorschia.Processing;

namespace Sorschia.DailyTask.EntityProcesses
{
    public interface IDeleteDTask : IProcess<IDTask>
    {
        IDTask DTask { get; set; }
    }
}
