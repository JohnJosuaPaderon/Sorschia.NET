using Sorschia.Processing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Manager
{
    partial class AssignmentStatusManager
    {
        public IProcessResult<IAssignmentStatus> Get(short id)
        {
            if (id > 0)
            {
                if (Source.ContainsId(id))
                {
                    return ProcessResult<IAssignmentStatus>.Success(Source[id]);
                }
                else
                {
                    using (var context = GenerateContext())
                    {
                        throw new NotImplementedException();
                        //using (var process = SorschiaApp.GetService<IGetAssignmentStatus>())
                        //{
                        //    process.Id = id;
                        //    return TryAddUpdate(process.Execute(context));
                        //}
                    }
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<IAssignmentStatus>> GetAsync(short id)
        {
            if (id > 0)
            {
                if (Source.ContainsId(id))
                {
                    return ProcessResult<IAssignmentStatus>.Success(Source[id]);
                }
                else
                {
                    using (var context = GenerateContext())
                    {
                        throw new NotImplementedException();
                        //using (var process = SorschiaApp.GetService<IGetAssignmentStatus>())
                        //{
                        //    process.Id = id;
                        //    return TryAddUpdate(await process.ExecuteAsync(context));
                        //}
                    }
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<IAssignmentStatus>> GetAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (Source.ContainsId(id))
                {
                    return ProcessResult<IAssignmentStatus>.Success(Source[id]);
                }
                else
                {
                    using (var context = GenerateContext())
                    {
                        throw new NotImplementedException();
                        //using (var process = SorschiaApp.GetService<IGetAssignmentStatus>())
                        //{
                        //    process.Id = id;
                        //    return TryAddUpdate(await process.ExecuteAsync(context, cancellationToken));
                        //}
                    }
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }
    }
}
