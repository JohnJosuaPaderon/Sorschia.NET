using Sorschia.Entity;
using System;

namespace MyDayManager.Entity
{
    public interface IAssignment : IEntity<long>
    {
        string Title { get; set; }
        string Description { get; set; }
        IAssignmentStatus Status { get; set; }
        DateTime Date { get; set; }
    }
}
