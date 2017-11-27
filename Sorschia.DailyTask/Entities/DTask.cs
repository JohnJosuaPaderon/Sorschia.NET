using Sorschia.Entities;
using System;

namespace Sorschia.DailyTask.Entities
{
    public class DTask : EntityBase<long>, IDTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DTaskStatus Status { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
