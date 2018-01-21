using MyDayManager.Entity.Process;
using Sorschia.Events;
using Sorschia.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Manager
{
    internal sealed partial class AssignmentStatusManager : CoreEntityManagerBase<IAssignmentStatus, short>, IAssignmentStatusManager
    {
        public AssignmentStatusManager(
            ISorschiaEventManager eventManager,
            IProcessContextFactory contextFactory,
            IGetAssignmentStatus get,
            IGetAssignmentStatusByKey getByKey) : base(eventManager, contextFactory)
        {
            _Get = get;
            _GetByKey = getByKey;
            _InvalidIdentifierResult = ProcessResult<IAssignmentStatus>.Failed("Assignment Status Identifier is invalid.");
            _InvalidKeyResult = ProcessResult<IAssignmentStatus>.Failed("Assignment Status Key is invalid.");
        }
    }
}
