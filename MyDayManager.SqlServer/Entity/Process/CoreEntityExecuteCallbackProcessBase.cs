using Sorschia.Data;
using Sorschia.Entity;
using Sorschia.Entity.Process;
using System.Data.SqlClient;

namespace MyDayManager.Entity.Process
{
    public abstract class CoreEntityExecuteCallbackProcessBase<T, TIdentifier> : SqlEntityExecuteCallbackProcessBase<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        public CoreEntityExecuteCallbackProcessBase(IDbProcessor<SqlCommand> processor) : base(processor)
        {
        }
    }
}
