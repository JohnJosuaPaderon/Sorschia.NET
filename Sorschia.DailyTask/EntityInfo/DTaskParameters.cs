namespace Sorschia.DailyTask.EntityInfo
{
    public sealed class DTaskParameters : IDTaskParameters
    {
        public DTaskParameters()
        {
            Id = "@_Id";
            Title = "@_Title";
            Description = "@_Description";
            ScheduledDate = "@_ScheduledDate";
            Status = "@_Status";
        }

        public string Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string ScheduledDate { get; }
        public string Status { get; }
    }
}
