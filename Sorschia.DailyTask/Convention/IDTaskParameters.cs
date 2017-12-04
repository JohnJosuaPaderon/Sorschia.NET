using Sorschia.Convention;

namespace Sorschia.DailyTask.Convention
{
    public interface IDTaskParameters : IEntityParameters
    {
        string Title { get; }
        string Description { get; }
        string ScheduledDate { get; }
        string Status { get; }
    }
}
