using Sorschia.Configurations;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public sealed class SqlConnectionProvider : IDbConnectionProvider<SqlConnection>
    {
        public SqlConnectionProvider(IConnectionStringSource connectionStringSource)
        {
            _ConnectionStringSource = connectionStringSource ?? throw new SorschiaException(SorschiaExceptionKind.ValueRequired);
        }

        private readonly IConnectionStringSource _ConnectionStringSource;

        private SqlConnection Instantiate(string connectionStringKey)
        {
            if (string.IsNullOrWhiteSpace(connectionStringKey))
            {
                throw new SorschiaException(SorschiaExceptionKind.KeyRequired);
            }

            return new SqlConnection(_ConnectionStringSource[connectionStringKey]);
        }

        public SqlConnection Establish(string connectionStringKey)
        {
            var connection = Instantiate(connectionStringKey);

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }

            return connection;
        }

        public async Task<SqlConnection> EstablishAsync(string connectionStringKey)
        {
            var connection = Instantiate(connectionStringKey);

            try
            {
                await connection.OpenAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return connection;
        }

        public async Task<SqlConnection> EstablishAsync(string connectionStringKey, CancellationToken cancellationToken)
        {
            var connection = Instantiate(connectionStringKey);

            try
            {
                await connection.OpenAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }

            return connection;
        }
    }
}
