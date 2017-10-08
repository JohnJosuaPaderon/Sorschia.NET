namespace Sorschia.DailyTask.EntityInfo
{
    public interface IDTaskParameters
    {
        string Id { get; }
        string Title { get; }
        string Description { get; }
        string ScheduledDate { get; }
        string Status { get; }
    }
}
