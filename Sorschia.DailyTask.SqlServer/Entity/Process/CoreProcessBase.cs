using Sorschia.Data;
using System.Data.SqlClient;

namespace Sorschia.DailyTask.Entity.Process
{
    public abstract class CoreProcessBase : SqlProcessBase
    {
        public CoreProcessBase(IDbProcessor<SqlCommand> processor) : base(processor, "dbo")
        {
        }
    }
}
