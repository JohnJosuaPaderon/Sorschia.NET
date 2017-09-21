using Sorschia.Entities;
using System;

namespace Sorschia.DevTeam.Entities
{
    public interface IAssignment : IEntity<long>
    {
        ValueRange<DateTime> TimeFrame { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        AssignmentStatus Status { get; set; }
    }
}
