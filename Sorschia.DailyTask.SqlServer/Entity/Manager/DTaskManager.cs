using Sorschia.DailyTask.Entity.Process;
using Sorschia.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.Entity.Manager
{
    public sealed class DTaskManager : CoreEntityManagerBase<IDTask, long>, IDTaskManager
    {
        public DTaskManager(IProcessContextFactory contextFactory, IInsertDTask insert) : base(contextFactory)
        {
            _Insert = insert;
            _InvalidResult = ProcessResult<IDTask>.Failed("Invalid Task.");
        }

        private readonly IInsertDTask _Insert;
        private readonly IProcessResult<IDTask> _InvalidResult;

        public IProcessResult<IDTask> Insert(IDTask dTask)
        {
            if (dTask != null)
            {
                using (var context = GenerateContext())
                {
                    _Insert.DTask = dTask;
                    return _Insert.Execute(context);
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IDTask>> InsertAsync(IDTask dTask)
        {
            if (dTask != null)
            {
                using (var context = GenerateContext())
                {
                    _Insert.DTask = dTask;
                    return await _Insert.ExecuteAsync(context);
                }
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IDTask>> InsertAsync(IDTask dTask, CancellationToken cancellationToken)
        {
            if (dTask != null)
            {
                using (var context = GenerateContext())
                {
                    _Insert.DTask = dTask;
                    return await _Insert.ExecuteAsync(context, cancellationToken);
                }
            }
            else
            {
                return _InvalidResult;
            }
        }
    }
}
