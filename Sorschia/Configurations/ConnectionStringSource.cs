using Sorschia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Sorschia.Configurations
{
    public abstract class ConnectionStringSource : IConnectionStringSource
    {
        protected ConnectionStringSource()
        {
            _Source = new Dictionary<string, SecureString>();
            IsDataLoaded = false;
        }

        private readonly Dictionary<string, SecureString> _Source;
        private bool IsDataLoaded;

        protected abstract void Initialize();

        private void TryInitialize()
        {
            if (!IsDataLoaded)
            {
                Initialize();
            }
        }

        protected void Initialize(IDictionary<string, string> connectionStrings)
        {
            if (connectionStrings == null)
            {
                throw new SorschiaException(SorschiaExceptionType.UnexpectedNull);
            }
            else if (!connectionStrings.Any())
            {
                throw new SorschiaException(SorschiaExceptionType.EmptyCollection);
            }
            else
            {
                foreach (var item in connectionStrings)
                {
                    _Source.Add(item.Key, SecureStringConverter.Convert(item.Value));
                }

                IsDataLoaded = true;
            }
        }

        public virtual string this[string key]
        {
            get
            {

                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new SorschiaException(SorschiaExceptionType.KeyRequired);
                }
                else
                {
                    TryInitialize();

                    if (!_Source.ContainsKey(key))
                    {
                        throw new SorschiaException(SorschiaExceptionType.KeyNotFound);
                    }
                    else
                    {
                        return SecureStringConverter.Convert(_Source[key]);
                    }
                }
            }
        }

        public virtual void Add(string key, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new SorschiaException(SorschiaExceptionType.KeyRequired);
            }
            else
            {
                TryInitialize();

                if (_Source.ContainsKey(key))
                {
                    throw new SorschiaException(SorschiaExceptionType.KeyAlreadyExists);
                }
                else
                {
                    _Source.Add(key, SecureStringConverter.Convert(connectionString));
                }
            }
        }

        public virtual void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new SorschiaException(SorschiaExceptionType.KeyRequired);
            }
            else
            {
                TryInitialize();

                if (!_Source.ContainsKey(key))
                {
                    throw new SorschiaException(SorschiaExceptionType.KeyNotFound);
                }
                else
                {
                    _Source.Remove(key);
                }
            }
        }

        public virtual void Update(string key, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new SorschiaException(SorschiaExceptionType.KeyRequired);
            }
            else
            {
                TryInitialize();

                if (!_Source.ContainsKey(key))
                {
                    throw new SorschiaException(SorschiaExceptionType.KeyNotFound);
                }
                else
                {
                    _Source[key] = SecureStringConverter.Convert(connectionString);
                }
            }
        }

        protected IDictionary<string, string> GetUnsafe()
        {
            var result = new Dictionary<string, string>();

            foreach (var item in _Source)
            {
                result.Add(item.Key, SecureStringConverter.Convert(item.Value));
            }

            return result;
        }

        protected IDictionary<string, string> GetEncrypted(Func<string, string> encrypt)
        {
            var result = new Dictionary<string, string>();

            foreach (var item in _Source)
            {
                result.Add(item.Key, encrypt(SecureStringConverter.Convert(item.Value)));
            }

            return result;
        }
    }
}
