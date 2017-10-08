namespace Sorschia.DailyTask.EntityInfo
{
    public sealed class DTaskFields : IDTaskFields
    {
        public DTaskFields()
        {
            Id = "Id";
            Title = "Title";
            Description = "Description";
            ScheduledDate = "ScheduledDate";
            Status = "Status";
        }

        public string Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string ScheduledDate { get; }
        public string Status { get; }
    }
}
