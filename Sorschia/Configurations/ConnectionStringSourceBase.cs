﻿using Sorschia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Sorschia.Configurations
{
    public abstract class ConnectionStringSourceBase : IConnectionStringSource
    {
        protected ConnectionStringSourceBase()
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
                throw new SorschiaException(SorschiaExceptionKind.UnexpectedNull);
            }
            else if (!connectionStrings.Any())
            {
                throw new SorschiaException(SorschiaExceptionKind.EmptyCollection);
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

                ValidateKey(key);
                TryInitialize();

                if (!_Source.ContainsKey(key))
                {
                    throw new SorschiaException(SorschiaExceptionKind.KeyNotFound);
                }
                else
                {
                    return SecureStringConverter.Convert(_Source[key]);
                }
            }
        }

        public virtual void Add(string key, string connectionString)
        {
            ValidateKey(key);
            TryInitialize();

            if (_Source.ContainsKey(key))
            {
                throw new SorschiaException(SorschiaExceptionKind.KeyAlreadyExists);
            }
            else
            {
                _Source.Add(key, SecureStringConverter.Convert(connectionString));
            }
        }

        public virtual void Remove(string key)
        {
            ValidateKey(key);
            TryInitialize();

            if (!_Source.ContainsKey(key))
            {
                throw new SorschiaException(SorschiaExceptionKind.KeyNotFound);
            }
            else
            {
                _Source.Remove(key);
            }
        }

        public virtual void Update(string key, string connectionString)
        {
            ValidateKey(key);
            TryInitialize();

            if (!_Source.ContainsKey(key))
            {
                throw new SorschiaException(SorschiaExceptionKind.KeyNotFound);
            }
            else
            {
                _Source[key] = SecureStringConverter.Convert(connectionString);
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

        private void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new SorschiaException(SorschiaExceptionKind.KeyRequired);
            }
        }
    }
}
