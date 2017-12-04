using System;

namespace Sorschia.DailyTask.Entity
{
    [Flags]
    public enum DTaskStatus
    {
        Waiting = 0,
        Ongoing = 1,
        Finished = 2
    }
}
