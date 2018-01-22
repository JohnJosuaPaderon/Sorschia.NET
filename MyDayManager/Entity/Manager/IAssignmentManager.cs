using Sorschia.Processing;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Manager
{
    public interface IAssignmentManager
    {
        IProcessResult<IAssignment> Insert(IAssignment assignment);
        Task<IProcessResult<IAssignment>> InsertAsync(IAssignment assignment);
        Task<IProcessResult<IAssignment>> InsertAsync(IAssignment assignment, CancellationToken cancellationToken);
        IProcessResult<IAssignment> Update(IAssignment assignment);
        Task<IProcessResult<IAssignment>> UpdateAsync(IAssignment assignment);
        Task<IProcessResult<IAssignment>> UpdateAsync(IAssignment assignment, CancellationToken cancellationToken);
        IProcessResult<IAssignment> Delete(IAssignment assignment);
        Task<IProcessResult<IAssignment>> DeleteAsync(IAssignment assignment);
        Task<IProcessResult<IAssignment>> DeleteAsync(IAssignment assignment, CancellationToken cancellationToken);
        IAggregateProcessResult<IAssignment> Delete(IEnumerable<IAssignment> assignments);
        Task<IAggregateProcessResult<IAssignment>> DeleteAsync(IEnumerable<IAssignment> assignments);
        Task<IAggregateProcessResult<IAssignment>> DeleteAsync(IEnumerable<IAssignment> assignments, CancellationToken cancellationToken);
        IAggregateProcessResult<IAssignment> Insert(IEnumerable<IAssignment> assignments);
        Task<IAggregateProcessResult<IAssignment>> InsertAsync(IEnumerable<IAssignment> assignments);
        Task<IAggregateProcessResult<IAssignment>> InsertAsync(IEnumerable<IAssignment> assignments, CancellationToken cancellationToken);
        IAggregateProcessResult<IAssignment> Update(IEnumerable<IAssignment> assignments);
        Task<IAggregateProcessResult<IAssignment>> UpdateAsync(IEnumerable<IAssignment> assignments);
        Task<IAggregateProcessResult<IAssignment>> UpdateAsync(IEnumerable<IAssignment> assignments, CancellationToken cancellationToken);
    }
}
