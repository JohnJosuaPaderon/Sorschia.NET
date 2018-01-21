using Sorschia;
using Sorschia.Events;
using System.Collections.Generic;

namespace MyDayManager.Entity.Event
{
    public sealed class AssignmentEnumerableUpdatedFeed : SorschiaEventFeedBase, ISorschiaEventFeed
    {
        public AssignmentEnumerableUpdatedFeed(IEnumerable<IAssignment> assignments)
        {
            Assignments = assignments ?? throw SorschiaException.ParameterRequired(nameof(assignments));
        }

        public IEnumerable<IAssignment> Assignments { get; }
    }
}
