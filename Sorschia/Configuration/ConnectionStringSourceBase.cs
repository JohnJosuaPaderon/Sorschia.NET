using Sorschia.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;

namespace Sorschia.Configuration
{
    public abstract class ConnectionStringSourceBase : IConnectionStringSource
    {
        public ConnectionStringSourceBase(IConnectionStringSourceLoader loader)
        {
            IsLoaded = false;
            _SecureSource = new Dictionary<string, SecureString>();
            _Loader = loader;
        }

        private readonly Dictionary<string, SecureString> _SecureSource;
        private readonly IConnectionStringSourceLoader _Loader;

        private bool IsLoaded;

        public string this[string key]
        {
            get
            {
                TryInitialize();
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
                TryInitialize();
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
            TryInitialize();
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
            TryInitialize();
            _SecureSource.Clear();
        }

        public void Remove(string key)
        {
            TryInitialize();
            _SecureSource.Remove(key);
        }

        public void Initialize()
        {
            _Loader.Load(this);
        }

        private void TryInitialize()
        {
            try
            {
                if (!IsLoaded)
                {
                    IsLoaded = true;
                    Initialize();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
