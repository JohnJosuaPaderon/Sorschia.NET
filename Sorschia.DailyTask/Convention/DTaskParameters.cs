﻿using Sorschia.Convention;

namespace Sorschia.DailyTask.Convention
{
    public sealed class DTaskParameters : EntityParametersBase, IDTaskParameters
    {
        public DTaskParameters(IEntityParameterFormatter formatter) : base(formatter)
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