using Sorschia;
using Sorschia.Events;
using System.Collections.Generic;

namespace MyDayManager.Entity.Event
{
    public sealed class AssignmentEnumerableDeletedFeed : SorschiaEventFeedBase, ISorschiaEventFeed
    {
        public AssignmentEnumerableDeletedFeed(IEnumerable<IAssignment> assignments)
        {
            Assignments = assignments ?? throw SorschiaException.ParameterRequired(nameof(assignments));
        }

        public IEnumerable<IAssignment> Assignments { get; }
    }
}
