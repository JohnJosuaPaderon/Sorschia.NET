using MyDayManager.Entity.Process;
using Sorschia.Processing;

namespace MyDayManager.Entity.Manager
{
    partial class AssignmentStatusManager
    {
        private readonly IGetAssignmentStatus _Get;
        private readonly IGetAssignmentStatusByKey _GetByKey;
        private readonly IProcessResult<IAssignmentStatus> _InvalidIdentifierResult;
        private readonly IProcessResult<IAssignmentStatus> _InvalidKeyResult;
    }
}
