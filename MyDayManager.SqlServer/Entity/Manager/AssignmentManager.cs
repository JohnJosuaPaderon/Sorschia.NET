using MyDayManager.Entity.Event;
using MyDayManager.Entity.Process;
using Sorschia.Events;
using Sorschia.Processing;

namespace MyDayManager.Entity.Manager
{
    internal sealed partial class AssignmentManager : CoreEntityManagerBase<IAssignment, long>, IAssignmentManager
    {
        public AssignmentManager(
            ISorschiaEventManager eventManager,
            IProcessContextFactory contextFactory,
            IDeleteAssignment delete,
            IInsertAssignment insert,
            IUpdateAssignment update) : base(eventManager, contextFactory)
        {
            _Delete = delete;
            _Insert = insert;
            _Update = update;
            _InvalidResult = ProcessResult<IAssignment>.Failed("Assignment is invalid.");
            _EmptyResult = AggregateProcessResult<IAssignment>.Failed("Empty Assignment collection.");

            if (EventHandlersEnabled)
            {
                _Added = eventManager.GetEvent<AssignmentAddedFeed>();
                _EnumerableAdded = eventManager.GetEvent<AssignmentEnumerableAddedFeed>();
                _Updated = eventManager.GetEvent<AssignmentUpdatedFeed>();
                _EnumerableUpdated = eventManager.GetEvent<AssignmentEnumerableUpdatedFeed>();
                _Deleted = eventManager.GetEvent<AssignmentDeletedFeed>();
                _EnumerableDeleted = eventManager.GetEvent<AssignmentEnumerableDeletedFeed>();
            }
        }
    }
}
