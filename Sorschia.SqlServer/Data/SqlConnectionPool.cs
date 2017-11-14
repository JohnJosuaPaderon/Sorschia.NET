using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sorschia.Data
{
    public sealed class SqlConnectionPool : IConnectionPool<SqlConnection>
    {
        public SqlConnectionPool()
        {
            _Source = new Dictionary<Guid, SqlConnection>();
        }

        private readonly Dictionary<Guid, SqlConnection> _Source;

        public SqlConnection this[Guid guid]
        {
            get => _Source[guid];
            set => AddUpdate(guid, value); }

        private void AddUpdate(Guid guid, SqlConnection connection)
        {
            RunMaintenance();

            if (_Source.ContainsKey(guid))
            {
                _Source[guid] = connection;
            }
            else
            {
                _Source.Add(guid, connection);
            }
        }

        private void RunMaintenance()
        {
            var removables = new List<Guid>();

            foreach (var kvp in _Source)
            {
                if (kvp.Value == null && kvp.Value.State == ConnectionState.Closed)
                {
                    removables.Add(kvp.Key);
                }
            }

            foreach (var guid in removables)
            {
                _Source.Remove(guid);
            }
        }
    }
}
