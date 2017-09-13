using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Data
{
    public class QueryParameterCollection<T> : IQueryParameterCollection<T>
        where T : IQueryParameter
    {
        internal QueryParameterCollection()
        {
            _Parameters = new Dictionary<string, T>();
        }

        private readonly Dictionary<string, T> _Parameters;

        public T this[string name]
        {
            get
            {
                if (Exists(name))
                {
                    return _Parameters[name];
                }
                else
                {
                    return default(T);
                }
            }
            set
            {
                if (Exists(name))
                {
                    _Parameters[name] = value;
                }
                else
                {
                    _Parameters.Add(name, value);
                }
            }
        }

        public void Add(T parameter)
        {
            if (!Exists(parameter))
            {
                _Parameters.Add(parameter.Name, parameter);
            }
        }

        public bool Exists(T parameter)
        {
            if (parameter != null)
            {
                return Exists(parameter.Name);
            }
            else
            {
                return false;
            }
        }

        public void Remove(T parameter)
        {
            if (parameter != null)
            {
                Remove(parameter.Name);
            }
        }

        public void Remove(string parameterName)
        {
            if (Exists(parameterName))
            {
                _Parameters.Remove(parameterName);
            }
        }

        public bool Exists(string parameterName)
        {
            if (!string.IsNullOrWhiteSpace(parameterName))
            {
                return _Parameters.ContainsKey(parameterName);
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            _Parameters.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _Parameters.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
