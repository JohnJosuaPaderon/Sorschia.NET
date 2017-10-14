using Sorschia.Convention;

namespace Sorschia.DailyTask.EntityInfo
{
    public interface IDTaskFields : IEntityFields
    {
        string Title { get; }
        string Description { get; }
        string ScheduledDate { get; }
        string Status { get; }
    }
}
