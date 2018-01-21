using Sorschia.Processing;
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
                        _Get.Id = id;
                        return TryAddUpdate(_Get.Execute(context));
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
                        _Get.Id = id;
                        return TryAddUpdate(await _Get.ExecuteAsync(context));
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
                        _Get.Id = id;
                        return TryAddUpdate(await _Get.ExecuteAsync(context, cancellationToken));
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
