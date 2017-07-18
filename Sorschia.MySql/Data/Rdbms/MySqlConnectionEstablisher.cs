using MySql.Data.MySqlClient;
using Sorschia.Configurations;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data.Rdbms
{
    public sealed class MySqlConnectionEstablisher : IMySqlConnectionEstablisher
    {
        private readonly ConnectionString ConnectionString;

        public MySqlConnectionEstablisher(ConnectionString connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection Instantiate()
        {
            return new MySqlConnection(SecureStringConverter.Convert(ConnectionString.SecureValue));
        }

        public MySqlConnection Establish()
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

        public async Task<MySqlConnection> EstablishAsync()
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

        public async Task<MySqlConnection> EstablishAsync(CancellationToken cancellationToken)
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
