using Sorschia.Convention;

namespace Sorschia.DailyTask.EntityInfo
{
    public sealed class DTaskFields : EntityFieldsBase, IDTaskFields
    {
        public DTaskFields(IEntityFieldFormatter formatter) : base(formatter)
        {
            Title = _Formatter.Format(nameof(Title));
            Description = _Formatter.Format(nameof(Description));
            ScheduledDate = _Formatter.Format(nameof(ScheduledDate));
            Status = _Formatter.Format(nameof(Status));
        }

        public string Title { get; }
        public string Description { get; }
        public string ScheduledDate { get; }
        public string Status { get; }
    }
}
