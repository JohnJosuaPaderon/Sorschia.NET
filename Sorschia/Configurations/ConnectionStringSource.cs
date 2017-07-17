using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Sorschia.Configurations
{
    public sealed class ConnectionStringSource
    {
        public ConnectionStringSource(bool isEncrypted, IEnumerable<ConnectionString> connectionStrings)
        {
            IsEncrypted = isEncrypted;
            ConnectionStrings = new Dictionary<string, ConnectionString>(connectionStrings.ToDictionary(cs => cs.Key));
        }

        private Dictionary<string, ConnectionString> ConnectionStrings { get; }
        public bool IsEncrypted { get; set; }

        public SecureString this[string key]
        {
            get
            {
                ValidateKey(key);
                KeyMustExists(key);
                return ConnectionStrings[key].SecureValue;
            }
            set
            {
                ValidateKey(key);
                KeyMustExists(key);
                ConnectionStrings[key].SecureValue = value;
            }
        }

        public void Add(ConnectionString connectionString)
        {
            ValidateConnectionString(connectionString);
            ValidateKey(connectionString.Key);
            KeyMustNotExists(connectionString.Key);

            ConnectionStrings.Add(connectionString.Key, connectionString);
        }

        public void Clear()
        {
            ConnectionStrings.Clear();
        }

        public void Remove(ConnectionString connectionString)
        {
            ValidateConnectionString(connectionString);
            ValidateKey(connectionString.Key);
            KeyMustExists(connectionString.Key);

            ConnectionStrings.Remove(connectionString.Key);
        }

        private void ValidateConnectionString(ConnectionString connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString), "Invalid connection string.");
            }
        }

        private void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException(nameof(key), "Invalid connection string key.");
            }
        }

        private void KeyMustExists(string key)
        {
            if (!ConnectionStrings.ContainsKey(key))
            {
                throw new ArgumentException(nameof(key), "Connection string key doesn't exists.");
            }
        }

        private void KeyMustNotExists(string key)
        {
            if (ConnectionStrings.ContainsKey(key))
            {
                throw new ArgumentException(nameof(key), "Connection string key already exists.");
            }
        }
    }
}
