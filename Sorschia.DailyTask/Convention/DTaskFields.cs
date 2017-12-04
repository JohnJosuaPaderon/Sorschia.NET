using Sorschia.Convention;

namespace Sorschia.DailyTask.Convention
{
    public sealed class DTaskFields : EntityFieldsBase, IDTaskFields
    {
        public DTaskFields(IEntityFieldFormatter formatter) : base(formatter)
        {
            Title = formatter.Format(nameof(Title));
            Description = formatter.Format(nameof(Description));
            ScheduledDate = formatter.Format(nameof(ScheduledDate));
            Status = formatter.Format(nameof(Status));
        }

        public string Title { get; }
        public string Description { get; }
        public string ScheduledDate { get; }
        public string Status { get; }
    }
}
