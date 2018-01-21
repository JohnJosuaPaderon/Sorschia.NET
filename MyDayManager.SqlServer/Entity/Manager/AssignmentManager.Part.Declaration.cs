using MyDayManager.Entity.Event;
using MyDayManager.Entity.Process;
using Sorschia.Events;
using Sorschia.Processing;

namespace MyDayManager.Entity.Manager
{
    partial class AssignmentManager
    {
        private readonly IDeleteAssignment _Delete;
        private readonly IInsertAssignment _Insert;
        private readonly IUpdateAssignment _Update;
        private readonly IProcessResult<IAssignment> _InvalidResult;
        private readonly IAggregateProcessResult<IAssignment> _EmptyResult;
        private readonly ISorschiaEvent<AssignmentAddedFeed> _Added;
        private readonly ISorschiaEvent<AssignmentEnumerableAddedFeed> _EnumerableAdded;
        private readonly ISorschiaEvent<AssignmentUpdatedFeed> _Updated;
        private readonly ISorschiaEvent<AssignmentEnumerableUpdatedFeed> _EnumerableUpdated;
        private readonly ISorschiaEvent<AssignmentDeletedFeed> _Deleted;
        private readonly ISorschiaEvent<AssignmentEnumerableDeletedFeed> _EnumerableDeleted;
    }
}
