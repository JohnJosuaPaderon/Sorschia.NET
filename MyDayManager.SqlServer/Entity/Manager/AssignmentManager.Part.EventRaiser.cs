using MyDayManager.Entity.Event;
using System.Collections.Generic;

namespace MyDayManager.Entity.Manager
{
    partial class AssignmentManager
    {
        protected override void OnAdded(IAssignment assignment)
        {
            _Added.Raise(new AssignmentAddedFeed(assignment));
        }

        protected override void OnAdded(IEnumerable<IAssignment> assignments)
        {
            _EnumerableAdded.Raise(new AssignmentEnumerableAddedFeed(assignments));
        }

        protected override void OnDeleted(IAssignment assignment)
        {
            _Deleted.Raise(new AssignmentDeletedFeed(assignment));
        }

        protected override void OnDeleted(IEnumerable<IAssignment> assignments)
        {
            _EnumerableDeleted.Raise(new AssignmentEnumerableDeletedFeed(assignments));
        }

        protected override void OnUpdated(IAssignment assignment)
        {
            _Updated.Raise(new AssignmentUpdatedFeed(assignment));
        }

        protected override void OnUpdated(IEnumerable<IAssignment> assignments)
        {
            _EnumerableUpdated.Raise(new AssignmentEnumerableUpdatedFeed(assignments));
        }
    }
}
