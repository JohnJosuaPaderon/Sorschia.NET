using Sorschia.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Manager
{
    partial class AssignmentManager
    {
        public IProcessResult<IAssignment> Update(IAssignment assignment)
        {
            if (assignment != null)
            {
                using (var context = GenerateContext())
                {
                    throw new NotImplementedException();
                    //using (var process = SorschiaApp.GetService<IUpdateAssignment>())
                    //{
                    //    process.Assignment = assignment;
                    //    return TryUpdate(process.Execute(context));
                    //}
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IAssignment>> UpdateAsync(IAssignment assignment)
        {
            if (assignment != null)
            {
                using (var context = GenerateContext())
                {
                    throw new NotImplementedException();
                    //using (var process = SorschiaApp.GetService<IUpdateAssignment>())
                    //{
                    //    process.Assignment = assignment;
                    //    return TryUpdate(await process.ExecuteAsync(context));
                    //}
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IAssignment>> UpdateAsync(IAssignment assignment, CancellationToken cancellationToken)
        {
            if (assignment != null)
            {
                using (var context = GenerateContext())
                {
                    throw new NotImplementedException();
                    //using (var process = SorschiaApp.GetService<IUpdateAssignment>())
                    //{
                    //    process.Assignment = assignment;
                    //    return TryUpdate(await process.ExecuteAsync(context, cancellationToken));
                    //}
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IAggregateProcessResult<IAssignment> Update(IEnumerable<IAssignment> assignments)
        {
            if (assignments != null && assignments.Any())
            {
                using (var context = GenerateContext())
                {
                    var result = new AggregateProcessResult<IAssignment>();

                    foreach (var assignment in assignments)
                    {
                        throw new NotImplementedException();
                        //using (var process = SorschiaApp.GetService<IUpdateAssignment>())
                        //{
                        //    process.Assignment = assignment;
                        //    result.Add(process.Execute(context));
                        //}
                    }

                    return TryUpdate(result);
                }
            }
            else
            {
                return _EmptyResult;
            }
        }

        public async Task<IAggregateProcessResult<IAssignment>> UpdateAsync(IEnumerable<IAssignment> assignments)
        {
            if (assignments != null && assignments.Any())
            {
                using (var context = GenerateContext())
                {
                    var result = new AggregateProcessResult<IAssignment>();

                    foreach (var assignment in assignments)
                    {
                        //using (var process = SorschiaApp.GetService<IUpdateAssignment>())
                        //{
                        //    process.Assignment = assignment;
                        //    result.Add(await process.ExecuteAsync(context));
                        //}
                    }

                    return TryUpdate(result);
                }
            }
            else
            {
                return _EmptyResult;
            }
        }

        public async Task<IAggregateProcessResult<IAssignment>> UpdateAsync(IEnumerable<IAssignment> assignments, CancellationToken cancellationToken)
        {
            if (assignments != null && assignments.Any())
            {
                using (var context = GenerateContext())
                {
                    var result = new AggregateProcessResult<IAssignment>();

                    foreach (var assignment in assignments)
                    {
                        //using (var process = SorschiaApp.GetService<IUpdateAssignment>())
                        //{
                        //    process.Assignment = assignment;
                        //    result.Add(await process.ExecuteAsync(context, cancellationToken));
                        //}
                    }

                    return TryUpdate(result);
                }
            }
            else
            {
                return _EmptyResult;
            }
        }
    }
}
