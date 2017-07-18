using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Sorschia.Processes;

namespace Sorschia.Data.Rdbms
{
    public sealed class MySqlHelper : IMySqlHelper
    {
        private readonly IMySqlConnectionEstablisher ConnectionEstablisher;

        public MySqlHelper(IMySqlConnectionEstablisher connectionEstablisher)
        {
            ConnectionEstablisher = connectionEstablisher ?? throw new ArgumentNullException(nameof(connectionEstablisher));
        }

        public IEnumerableProcessResult<T> ExecuteEnumerableReader<T>(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, IDataConverter<T, MySqlDataReader> converter)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return converter.EnumerableFromReader(reader);
                            }
                            else
                            {
                                return new EnumerableProcessResult<T>(ProcessResultStatus.NoData, "No result.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<T>(ex);
            }
        }

        public Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, IDataConverter<T, MySqlDataReader> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, IDataConverter<T, MySqlDataReader> converter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IProcessResult ExecuteNonQuery(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo)
        {
            throw new NotImplementedException();
        }

        public IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, MySqlConnection, MySqlCommand, MySqlParameter> queryInfo)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, MySqlConnection, MySqlCommand, MySqlParameter> queryInfo)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IProcessResult<T> ExecuteReader<T>(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, IDataConverter<T, MySqlDataReader> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, IDataConverter<T, MySqlDataReader> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, IDataConverter<T, MySqlDataReader> converter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, Func<object, T> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, Func<object, T> converter)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter> queryInfo, Func<object, T> converter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
