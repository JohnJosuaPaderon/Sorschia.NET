using Sorschia.Configurations;
using Sorschia.Utilities;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data.Rdbms
{
    public sealed class SqlConnectionEstablisher : ISqlConnectionEstablisher
    {
        private readonly ConnectionString ConnectionString;

        public SqlConnectionEstablisher(ConnectionString connectionString)
        {
            ConnectionString = connectionString;
        }

        private SqlConnection Instantiate()
        {
            return new SqlConnection(SecureStringConverter.Convert(ConnectionString.SecureValue));
        }

        public SqlConnection Establish()
        {
            var connection = Instantiate();

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

        public async Task<SqlConnection> EstablishAsync()
        {
            var connection = Instantiate();

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

        public async Task<SqlConnection> EstablishAsync(CancellationToken cancellationToken)
        {
            var connection = Instantiate();

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
