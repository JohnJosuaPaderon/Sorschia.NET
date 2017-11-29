using System.Data.SqlClient;

namespace Sorschia.Data
{
    public sealed class SqlProcessor : DbProcessorBase<SqlCommand>, IDbProcessor<SqlCommand>
    {
        public SqlProcessor(IDbCommandCreator<SqlCommand> commandCreator) : base(commandCreator)
        {
        }
    }
}
