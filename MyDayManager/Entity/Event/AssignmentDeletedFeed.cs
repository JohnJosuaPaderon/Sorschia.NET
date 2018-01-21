using Sorschia;
using Sorschia.Events;

namespace MyDayManager.Entity.Event
{
    public sealed class AssignmentDeletedFeed : SorschiaEventFeedBase, ISorschiaEventFeed
    {
        public AssignmentDeletedFeed(IAssignment assignment)
        {
            Assignment = assignment ?? throw SorschiaException.ParameterRequired(nameof(assignment));
        }

        public IAssignment Assignment { get; }
    }
}
