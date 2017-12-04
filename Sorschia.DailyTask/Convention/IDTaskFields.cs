using Sorschia.Convention;

namespace Sorschia.DailyTask.Convention
{
    public interface IDTaskFields : IEntityFields
    {
        string Title { get; }
        string Description { get; }
        string ScheduledDate { get; }
        string Status { get; }
    }
}
