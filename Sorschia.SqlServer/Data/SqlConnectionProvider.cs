using Sorschia.Configurations;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public sealed class SqlConnectionProvider : IDbConnectionProvider<SqlConnection>
    {
        public SqlConnectionProvider(IConnectionStringSource connectionStringSource, IConnectionPool<SqlConnection> connectionPool)
        {
            _ConnectionStringSource = connectionStringSource ?? throw new SorschiaException(SorschiaExceptionKind.ValueRequired);
            _ConnectionPool = connectionPool ?? throw new SorschiaException(SorschiaExceptionKind.ValueRequired);
        }

        private readonly IConnectionStringSource _ConnectionStringSource;
        private readonly IConnectionPool<SqlConnection> _ConnectionPool; 

        private SqlConnection Instantiate(string connectionStringKey)
        {
            if (string.IsNullOrWhiteSpace(connectionStringKey))
            {
                throw new SorschiaException(SorschiaExceptionKind.KeyRequired);
            }

            return new SqlConnection(_ConnectionStringSource[connectionStringKey]);
        }

        private void TrySaveToPool(Guid guid, SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                _ConnectionPool[guid] = connection;
            }
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

        public SqlConnection GetConnection(Guid guid)
        {
            return _ConnectionPool[guid];
        }

        public SqlConnection Establish(string connectionStringKey, Guid guid)
        {
            var connection = Establish(connectionStringKey);
            TrySaveToPool(guid, connection);
            return connection;
        }

        public async Task<SqlConnection> EstablishAsync(string connectionStringKey, Guid guid)
        {
            var connection = await EstablishAsync(connectionStringKey);
            TrySaveToPool(guid, connection);
            return connection;
        }

        public async Task<SqlConnection> EstablishAsync(string connectionStringKey, CancellationToken cancellationToken, Guid guid)
        {
            var connection = await EstablishAsync(connectionStringKey, cancellationToken);
            TrySaveToPool(guid, connection);
            return connection;
        }
    }
}
