using Sorschia.Utilities;

namespace Sorschia.Configuration
{
    partial class ConnectionStringSourceBase
    {
        public string this[string key]
        {
            get
            {
                ValidateKey(key);
                TryInitialize();
                if (_SecureSource.ContainsKey(key))
                {
                    return SecureStringConverter.Convert(_SecureSource[key]);
                }
                else
                {
                    throw NotFound();
                }
            }
            set
            {
                ValidateKey(key);
                ValidateConnectionString(value);
                TryInitialize();
                if (_SecureSource.ContainsKey(key))
                {
                    _SecureSource[key] = SecureStringConverter.Convert(value);
                }
                else
                {
                    throw NotFound();
                }
            }
        }

        public void Add(string key, string connectionString)
        {
            ValidateKey(key);
            TryInitialize();
            if (string.IsNullOrWhiteSpace(key))
            {
                throw SorschiaException.ParameterRequired(nameof(key));
            }
            else if (_SecureSource.ContainsKey(key))
            {
                throw AlreadyExists();
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
            ValidateKey(key);
            TryInitialize();
            _SecureSource.Remove(key);
        }

        public void Initialize()
        {
            _Loader.Load(this);
        }

        private SorschiaException NotFound()
        {
            return SorschiaException.CollectionItemNotExists("Connection string with the specified key doesn't exists.");
        }

        private SorschiaException AlreadyExists()
        {
            return SorschiaException.CollectionItemDuplication("Connection string with the specified key already exists.");
        }

        private void TryInitialize()
        {
            if (!IsLoaded)
            {
                IsLoaded = true;
                Initialize();
            }
        }

        private void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw SorschiaException.ParameterRequired(nameof(key));
            }
        }

        private void ValidateConnectionString(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw SorschiaException.ParameterRequired(nameof(connectionString));
            }
        }
    }
}
