using Sorschia.Utilities;
using System.Collections.Generic;
using System.Security;

namespace Sorschia.Configuration
{
    public abstract class ConnectionStringSourceBase : IConnectionStringSource
    {
        public ConnectionStringSourceBase(IConnectionStringSourceLoader loader)
        {
            _SecureSource = new Dictionary<string, SecureString>();
            _Loader = loader;
        }

        private readonly Dictionary<string, SecureString> _SecureSource;
        private readonly IConnectionStringSourceLoader _Loader;

        public string this[string key]
        {
            get
            {
                if (_SecureSource.ContainsKey(key))
                {
                    return SecureStringConverter.Convert(_SecureSource[key]);
                }
                else
                {
                    throw SorschiaException.CollectionItemNotExists("Connection string with the specified key doesn't exists.");
                }
            }
            set
            {
                if (_SecureSource.ContainsKey(key))
                {
                    _SecureSource[key] = SecureStringConverter.Convert(value);
                }
                else
                {
                    throw SorschiaException.CollectionItemNotExists("Connection string with the specified key doesn't exists.");
                }
            }
        }

        public void Add(string key, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw SorschiaException.ParameterRequired(nameof(key));
            }
            else if (_SecureSource.ContainsKey(key))
            {
                throw SorschiaException.CollectionItemDuplication("Connection string with the specified key already exists.");
            }
            else
            {
                _SecureSource.Add(key, SecureStringConverter.Convert(connectionString));
            }
        }

        public void Clear()
        {
            _SecureSource.Clear();
        }

        public void Remove(string key)
        {
            _SecureSource.Remove(key);
        }

        public void Initialize()
        {
            _Loader.Load(this);
        }
    }
}
