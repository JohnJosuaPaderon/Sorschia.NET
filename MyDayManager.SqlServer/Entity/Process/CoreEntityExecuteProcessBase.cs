using Sorschia.Data;
using Sorschia.Entity.Process;
using System.Data.SqlClient;

namespace MyDayManager.Entity.Process
{
    public abstract class CoreEntityExecuteProcessBase : SqlEntityExecuteProcessBase
    {
        public CoreEntityExecuteProcessBase(IDbProcessor<SqlCommand> processor) : base(processor)
        {
        }
    }
}
