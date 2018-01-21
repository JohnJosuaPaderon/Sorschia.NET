using Sorschia.Processing;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Manager
{
    partial class AssignmentManager
    {
        public IProcessResult<IAssignment> Delete(IAssignment assignment)
        {
            if (assignment != null)
            {
                using (var context = GenerateContext())
                {
                    _Delete.Assignment = assignment;
                    return TryRemove(_Delete.Execute(context));
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IAssignment>> DeleteAsync(IAssignment assignment)
        {
            if (assignment != null)
            {
                using (var context = GenerateContext())
                {
                    _Delete.Assignment = assignment;
                    return TryRemove(await _Delete.ExecuteAsync(context));
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IAssignment>> DeleteAsync(IAssignment assignment, CancellationToken cancellationToken)
        {
            if (assignment != null)
            {
                using (var context = GenerateContext())
                {
                    _Delete.Assignment = assignment;
                    return TryRemove(await _Delete.ExecuteAsync(context, cancellationToken));
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IAggregateProcessResult<IAssignment> Delete(IEnumerable<IAssignment> assignments)
        {
            if (assignments != null && assignments.Any())
            {
                using (var context = GenerateContext())
                {
                    var result = new AggregateProcessResult<IAssignment>();

                    foreach (var assignment in assignments)
                    {
                        _Delete.Assignment = assignment;
                        result.Add(_Delete.Execute(context));
                    }

                    return TryRemove(result);
                }
            }
            else
            {
                return _EmptyResult;
            }
        }

        public async Task<IAggregateProcessResult<IAssignment>> DeleteAsync(IEnumerable<IAssignment> assignments)
        {
            if (assignments != null && assignments.Any())
            {
                using (var context = GenerateContext())
                {
                    var result = new AggregateProcessResult<IAssignment>();

                    foreach (var assignment in assignments)
                    {
                        _Delete.Assignment = assignment;
                        result.Add(await _Delete.ExecuteAsync(context));
                    }

                    return TryRemove(result);
                }
            }
            else
            {
                return _EmptyResult;
            }
        }

        public async Task<IAggregateProcessResult<IAssignment>> DeleteAsync(IEnumerable<IAssignment> assignments, CancellationToken cancellationToken)
        {
            if (assignments != null && assignments.Any())
            {
                using (var context = GenerateContext())
                {
                    var result = new AggregateProcessResult<IAssignment>();

                    foreach (var assignment in assignments)
                    {
                        _Delete.Assignment = assignment;
                        result.Add(await _Delete.ExecuteAsync(context, cancellationToken));
                    }

                    return TryRemove(result);
                }
            }
            else
            {
                return _EmptyResult;
            }
        }
    }
}
