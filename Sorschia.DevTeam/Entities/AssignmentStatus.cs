using System;

namespace Sorschia.DevTeam.Entities
{
    [Flags]
    public enum AssignmentStatus
    {
        Waiting = 0,
        Ongoing = 1,
        Finished = 2
    }
}
