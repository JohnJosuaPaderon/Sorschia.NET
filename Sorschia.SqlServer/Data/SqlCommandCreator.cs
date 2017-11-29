using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public sealed class SqlCommandCreator : IDbCommandCreator<SqlCommand>
    {
        public SqlCommandCreator(
            IDbConnectionProvider<SqlConnection> connectionProvider,
            IDbTransactionProvider<SqlTransaction> transactionProvider,
            IDbQueryParameterConverter<SqlParameter> parameterConverter)
        {
            _ConnectionProvider = connectionProvider;
            _TransactionProvider = transactionProvider;
            _ParameterConverter = parameterConverter;
        }

        private readonly IDbConnectionProvider<SqlConnection> _ConnectionProvider;
        private readonly IDbTransactionProvider<SqlTransaction> _TransactionProvider;
        private readonly IDbQueryParameterConverter<SqlParameter> _ParameterConverter;

        private SqlCommand Create(IDbQuery query, SqlConnection connection, SqlTransaction transaction)
        {
            var command = new SqlCommand
            {
                CommandText = query.Text,
                Connection = connection,
                Transaction = transaction,
                CommandType = DbQueryTypeToCommandTypeConverter.Convert(query.Type)
            };

            foreach (var parameter in query.Parameters)
            {
                command.Parameters.Add(_ParameterConverter.Convert(parameter));
            }

            return command;
        }

        public SqlCommand Create(IDbQuery query, IProcessContext processContext)
        {
            return Create(query, _ConnectionProvider.Establish(processContext), _TransactionProvider[processContext]);
        }

        public async Task<SqlCommand> CreateAsync(IDbQuery query, IProcessContext processContext)
        {
            return Create(query, await _ConnectionProvider.EstablishAsync(processContext), _TransactionProvider[processContext]);
        }

        public async Task<SqlCommand> CreateAsync(IDbQuery query, IProcessContext processContext, CancellationToken cancellationToken)
        {
            return Create(query, await _ConnectionProvider.EstablishAsync(processContext, cancellationToken), _TransactionProvider[processContext]);
        }
    }
}
