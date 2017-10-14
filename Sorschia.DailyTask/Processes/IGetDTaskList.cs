using Sorschia.DailyTask.Entities;
using Sorschia.Processing;

namespace Sorschia.DailyTask.Processes
{
    public interface IGetDTaskList : IEnumerableProcess<IDTask>
    {
    }
}
