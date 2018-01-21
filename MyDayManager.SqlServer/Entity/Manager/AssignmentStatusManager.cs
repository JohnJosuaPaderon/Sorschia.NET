using MyDayManager.Entity.Process;
using Sorschia.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Manager
{
    internal sealed class AssignmentStatusManager : CoreEntityManagerBase<IAssignmentStatus, short>, IAssignmentStatusManager
    {
        public AssignmentStatusManager(IProcessContextFactory contextFactory, IGetAssignmentStatus get, IGetAssignmentStatusByKey getByKey) : base(contextFactory)
        {
            _Get = get;
            _GetByKey = getByKey;
            _InvalidIdentifier = ProcessResult<IAssignmentStatus>.Failed("Assignment Status Identifier is invalid.");
            _InvalidKey = ProcessResult<IAssignmentStatus>.Failed("Assignment Status Key is invalid.");
        }

        private readonly IGetAssignmentStatus _Get;
        private readonly IGetAssignmentStatusByKey _GetByKey;
        private readonly IProcessResult<IAssignmentStatus> _InvalidIdentifier;
        private readonly IProcessResult<IAssignmentStatus> _InvalidKey;

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
                    using (var context = _ContextFactory.Generate())
                    {
                        _Get.Id = id;
                        return TryAddUpdate(_Get.Execute(context));
                    }
                }
            }
            else
            {
                return _InvalidIdentifier;
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
                    using (var context = _ContextFactory.Generate())
                    {
                        _Get.Id = id;
                        return TryAddUpdate(await _Get.ExecuteAsync(context));
                    }
                }
            }
            else
            {
                return _InvalidIdentifier;
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
                    using (var context = _ContextFactory.Generate())
                    {
                        _Get.Id = id;
                        return TryAddUpdate(await _Get.ExecuteAsync(context, cancellationToken));
                    }
                }
            }
            else
            {
                return _InvalidIdentifier;
            }
        }

        public IProcessResult<IAssignmentStatus> GetByKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return _InvalidKey;
            }
            else
            {
                using (var context = _ContextFactory.Generate())
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
                return _InvalidKey;
            }
            else
            {
                using (var context = _ContextFactory.Generate())
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
                return _InvalidKey;
            }
            else
            {
                using (var context = _ContextFactory.Generate())
                {
                    _GetByKey.Key = key;
                    return TryAddUpdate(await _GetByKey.ExecuteAsync(context, cancellationToken));
                }
            }
        }
    }
}
