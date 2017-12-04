using Sorschia.Entity;
using System;

namespace Sorschia.DailyTask.Entity
{
    public interface IDTask : IEntity<long>
    {
        string Title { get; set; }
        string Description { get; set; }
        DateTime ScheduledDate { get; set; }
        DTaskStatus Status { get; set; }
    }
}
