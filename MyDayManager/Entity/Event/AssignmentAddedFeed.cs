using Sorschia;
using Sorschia.Events;

namespace MyDayManager.Entity.Event
{
    public sealed class AssignmentAddedFeed : SorschiaEventFeedBase, ISorschiaEventFeed
    {
        public AssignmentAddedFeed(IAssignment assignment)
        {
            Assignment = assignment ?? throw SorschiaException.ParameterRequired(nameof(assignment));
        }

        public IAssignment Assignment { get; }
    }
}
