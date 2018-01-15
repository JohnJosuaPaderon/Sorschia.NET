using Sorschia.DailyTask.Entity;
using Sorschia.Processing;

namespace Sorschia.DailyTask.Processes
{
    public interface IDeleteDTask : IProcess<IDTask>
    {
        IDTask DTask { get; set; }
    }
}
