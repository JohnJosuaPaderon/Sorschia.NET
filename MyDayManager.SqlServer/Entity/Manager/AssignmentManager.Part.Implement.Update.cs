using Sorschia.Processing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Manager
{
    partial class AssignmentManager
    {
        public IProcessResult<IAssignment> Update(IAssignment assignment)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<IAssignment>> UpdateAsync(IAssignment assignment)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<IAssignment>> UpdateAsync(IAssignment assignment, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
