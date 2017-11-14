﻿using Sorschia.Convention;

namespace Sorschia.DailyTask.EntityInfo
{
    public sealed class DTaskFields : EntityFieldsBase, IDTaskFields
    {
        public DTaskFields(IEntityInfoConfiguration configuration) : base(configuration)
        {
            Title = AppendPrefix(nameof(Title));
            Description = AppendPrefix(nameof(Description));
            ScheduledDate = AppendPrefix(nameof(ScheduledDate));
            Status = AppendPrefix(nameof(Status));
        }

        public string Title { get; }
        public string Description { get; }
        public string ScheduledDate { get; }
        public string Status { get; }
    }
}