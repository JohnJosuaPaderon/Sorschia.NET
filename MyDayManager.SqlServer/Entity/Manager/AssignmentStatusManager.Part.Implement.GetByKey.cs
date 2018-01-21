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
                    _GetByKey.Key = key;
                    return TryAddUpdate(_GetByKey.Execute(context));
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
                    _GetByKey.Key = key;
                    return TryAddUpdate(await _GetByKey.ExecuteAsync(context));
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
                    _GetByKey.Key = key;
                    return TryAddUpdate(await _GetByKey.ExecuteAsync(context, cancellationToken));
                }
            }
        }
    }
}
