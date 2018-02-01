using Sorschia.Utilities;
using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Configuration
{
    partial class ConnectionStringCollection
    {
        public string this[string key]
        {
            get
            {
                ConnectionStringValidator.ValidateKey(key);

                if (UnsafeContains(key))
                {
                    return SecureStringConverter.Convert(_Source[key].SecureValue);
                }
                else
                {
                    return default(string);
                }
            }
            set
            {
                ConnectionStringValidator.ValidateKey(key);
                ConnectionStringValidator.ValidateValue(value);

                if (UnsafeContains(key))
                {
                    _Source[key].SecureValue = SecureStringConverter.Convert(value);
                }
            }
        }

        public void Add(string key, string value)
        {
            ConnectionStringValidator.ValidateKey(key);
            ConnectionStringValidator.ValidateValue(value);

            if (!UnsafeContains(key))
            {
                UnsafeAdd(key, value);
            }
        }

        public void Add(IConnectionString connectionString)
        {
            ConnectionStringValidator.Validate(connectionString);

            if (!UnsafeContains(connectionString.Key))
            {
                UnsafeAdd(connectionString);
            }
        }

        public void Remove(string key)
        {
            ConnectionStringValidator.ValidateKey(key);

            if (UnsafeContains(key))
            {
                UnsafeRemove(key);
            }
        }

        public void Clear()
        {
            _Source.Clear();
        }

        public IEnumerator<IConnectionString> GetEnumerator()
        {
            return _Source.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
