using Sorschia.Data;
using System.Data.SqlClient;

namespace Sorschia.Entity.Process
{
    public abstract class SqlEntityProcessBase
    {
        public SqlEntityProcessBase(IDbProcessor<SqlCommand> processor, string schema = null)
        {
            _Schema = string.IsNullOrWhiteSpace(schema) ? LibraryResources.DefaultSchema : schema;
            _Processor = processor;
        }

        protected readonly string _Schema;
        protected readonly IDbProcessor<SqlCommand> _Processor;
        protected abstract IDbQuery Query { get; }

        protected string GetDbObjectName()
        {
            return $"{_Schema}.{GetType().Name}";
        }

        public virtual void Dispose()
        {
            // TODO: Dispose all used resources.
        }
    }
}
