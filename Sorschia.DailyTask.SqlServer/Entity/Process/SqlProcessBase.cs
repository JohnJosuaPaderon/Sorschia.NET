using Sorschia.Data;
using System.Data.SqlClient;

namespace Sorschia.DailyTask.Entity.Process
{
    public abstract class SqlProcessBase
    {
        public SqlProcessBase(IDbProcessor<SqlCommand> processor, string schema = null)
        {
            _Processor = processor;

            if (string.IsNullOrWhiteSpace(schema))
            {
                Schema = "dbo";
            }
            else
            {
                Schema = schema;
            }
        }

        protected readonly string Schema;
        protected readonly IDbProcessor<SqlCommand> _Processor;

        protected string GetDbObjectName()
        {
            return $"{Schema}.{GetType().Name}";
        }
    }
}
