using System;

namespace Sorschia.DailyTask.Entities
{
    [Flags]
    public enum DTaskStatus
    {
        Waiting = 0,
        Ongoing = 1,
        Finished = 2
    }
}
