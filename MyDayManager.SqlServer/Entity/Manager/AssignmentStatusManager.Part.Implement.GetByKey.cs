using MyDayManager.Entity.Process;
using Sorschia.Application;
using Sorschia.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Manager
{
    partial class AssignmentStatusManager
    {
        public IProcessResult<IAssignmentStatus> GetByKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return _InvalidKeyResult;
            }
            else
            {
                using (var context = GenerateContext())
                {
                    using (var process = SorschiaApp.GetService<IGetAssignmentStatusByKey>())
                    {
                        process.Key = key;
                        return TryAddUpdate(process.Execute(context));
                    }
                }
            }
        }

        public async Task<IProcessResult<IAssignmentStatus>> GetByKeyAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return _InvalidKeyResult;
            }
            else
            {
                using (var context = GenerateContext())
                {
                    using (var process = SorschiaApp.GetService<IGetAssignmentStatusByKey>())
                    {
                        process.Key = key;
                        return TryAddUpdate(await process.ExecuteAsync(context));
                    }
                }
            }
        }

        public async Task<IProcessResult<IAssignmentStatus>> GetByKeyAsync(string key, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return _InvalidKeyResult;
            }
            else
            {
                using (var context = GenerateContext())
                {
                    using (var process = SorschiaApp.GetService<IGetAssignmentStatusByKey>())
                    {
                        process.Key = key;
                        return TryAddUpdate(await process.ExecuteAsync(context, cancellationToken));
                    }
                }
            }
        }
    }
}
