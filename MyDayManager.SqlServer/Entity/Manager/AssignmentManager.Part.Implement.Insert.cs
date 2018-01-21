using Sorschia.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Manager
{
    partial class AssignmentManager
    {
        public IProcessResult<IAssignment> Insert(IAssignment assignment)
        {
            if (assignment != null)
            {
                using (var context = GenerateContext())
                {
                    _Insert.Assignment = assignment;
                    return TryAdd(_Insert.Execute(context));
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IAssignment>> InsertAsync(IAssignment assignment)
        {
            if (assignment != null)
            {
                using (var context = GenerateContext())
                {
                    _Insert.Assignment = assignment;
                    return TryAdd(await _Insert.ExecuteAsync(context));
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IAssignment>> InsertAsync(IAssignment assignment, CancellationToken cancellationToken)
        {
            if (assignment != null)
            {
                using (var context = GenerateContext())
                {
                    _Insert.Assignment = assignment;
                    return TryAdd(await _Insert.ExecuteAsync(context, cancellationToken));
                }
            }
            else
            {
                return _InvalidResult;
            }
        }
    }
}
