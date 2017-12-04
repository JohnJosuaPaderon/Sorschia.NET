using Sorschia.Processing;

namespace Sorschia.DailyTask.Entity.Process
{
    public interface IInsertDTask : IProcess<IDTask>
    {
        IDTask DTask { get; set; }
    }
}
