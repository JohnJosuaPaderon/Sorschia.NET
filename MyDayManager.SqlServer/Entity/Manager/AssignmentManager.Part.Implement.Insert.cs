using MyDayManager.Entity.Process;
using Sorschia.Application;
using Sorschia.Processing;
using System.Collections.Generic;
using System.Linq;
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
                    using (var process = SorschiaApp.GetService<IInsertAssignment>())
                    {
                        process.Assignment = assignment;
                        return TryAdd(process.Execute(context));
                    }
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
                    using (var process = SorschiaApp.GetService<IInsertAssignment>())
                    {
                        process.Assignment = assignment;
                        return TryAdd(await process.ExecuteAsync(context));
                    }
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
                    using (var process = SorschiaApp.GetService<IInsertAssignment>())
                    {
                        process.Assignment = assignment;
                        return TryAdd(await process.ExecuteAsync(context, cancellationToken));
                    }
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IAggregateProcessResult<IAssignment> Insert(IEnumerable<IAssignment> assignments)
        {
            if (assignments != null && assignments.Any())
            {
                using (var context = GenerateContext())
                {
                    var result = new AggregateProcessResult<IAssignment>();

                    foreach (var assignment in assignments)
                    {
                        using (var process = SorschiaApp.GetService<IInsertAssignment>())
                        {
                            process.Assignment = assignment;
                            result.Add(process.Execute(context));
                        }
                    }

                    return TryAdd(result);
                }
            }
            else
            {
                return _EmptyResult;
            }
        }

        public async Task<IAggregateProcessResult<IAssignment>> InsertAsync(IEnumerable<IAssignment> assignments)
        {
            if (assignments != null && assignments.Any())
            {
                using (var context = GenerateContext())
                {
                    var result = new AggregateProcessResult<IAssignment>();

                    foreach (var assignment in assignments)
                    {
                        using (var process = SorschiaApp.GetService<IInsertAssignment>())
                        {
                            process.Assignment = assignment;
                            result.Add(await process.ExecuteAsync(context));
                        }
                    }

                    return TryAdd(result);
                }
            }
            else
            {
                return _EmptyResult;
            }
        }

        public async Task<IAggregateProcessResult<IAssignment>> InsertAsync(IEnumerable<IAssignment> assignments, CancellationToken cancellationToken)
        {
            if (assignments != null && assignments.Any())
            {
                using (var context = GenerateContext())
                {
                    var result = new AggregateProcessResult<IAssignment>();

                    foreach (var assignment in assignments)
                    {
                        using (var process = SorschiaApp.GetService<IInsertAssignment>())
                        {
                            process.Assignment = assignment;
                            result.Add(await process.ExecuteAsync(context, cancellationToken));
                        }
                    }

                    return TryAdd(result);
                }
            }
            else
            {
                return _EmptyResult;
            }
        }
    }
}
