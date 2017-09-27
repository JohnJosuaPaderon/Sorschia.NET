using Sorschia.DailyTask.Entities;
using Sorschia.Processing;

namespace Sorschia.DailyTask.EntityProcesses
{
    public interface IGetDTaskList : IEnumerableProcess<IDTask>
    {
    }
}
