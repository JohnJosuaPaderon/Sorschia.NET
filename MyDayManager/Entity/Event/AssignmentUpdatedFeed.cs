using Sorschia;
using Sorschia.Events;

namespace MyDayManager.Entity.Event
{
    public sealed class AssignmentUpdatedFeed : SorschiaEventFeedBase, ISorschiaEventFeed
    {
        public AssignmentUpdatedFeed(IAssignment assignment)
        {
            Assignment = assignment ?? throw SorschiaException.ParameterRequired(nameof(assignment));
        }

        public IAssignment Assignment { get; }
    }
}
