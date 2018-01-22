using Sorschia.Events;
using Sorschia.Processing;

namespace MyDayManager.Entity.Manager
{
    internal sealed partial class AssignmentStatusManager : CoreEntityManagerBase<IAssignmentStatus, short>, IAssignmentStatusManager
    {
        public AssignmentStatusManager(ISorschiaEventManager eventManager, IProcessContextFactory contextFactory) : base(eventManager, contextFactory)
        {
            _InvalidIdentifierResult = ProcessResult<IAssignmentStatus>.Failed("Assignment Status Identifier is invalid.");
            _InvalidKeyResult = ProcessResult<IAssignmentStatus>.Failed("Assignment Status Key is invalid.");
        }
    }
}
