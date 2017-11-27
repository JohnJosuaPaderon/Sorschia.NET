using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Application
{
    public sealed class AppDirectoryCollection : IAppDirectoryCollection
    {
        public static AppDirectoryCollection Empty => new AppDirectoryCollection();

        public AppDirectoryCollection()
        {
            _Helper = AppDirectoryCollectionHelper.Instance;
            _Source = new Dictionary<string, IAppDirectory>();
        }

        private readonly AppDirectoryCollectionHelper _Helper;
        private readonly Dictionary<string, IAppDirectory> _Source;

        public IAppDirectory this[string key]
        {
            get
            {
                if (_Source.ContainsKey(key))
                {
                    return _Source[key];
                }
                else
                {
                    throw _Helper.ComposeItemNotExistsError(key);
                }
            }
            set
            {
                if (_Source.ContainsKey(key))
                {
                    _Source[key] = value;
                }
                else
                {
                    throw _Helper.ComposeItemNotExistsError(key);
                }
            }
        }

        public void Add(IAppDirectory directory)
        {
            _Helper.ValidateDirectory(directory);

            if (_Source.ContainsKey(directory.Key))
            {
                throw _Helper.ComposeItemDuplicationError(directory.Key);
            }
            else
            {
                _Source.Add(directory.Key, directory);
            }
        }

        public void Clear()
        {
            _Source.Clear();
        }

        public IEnumerator<IAppDirectory> GetEnumerator()
        {
            return _Source.Values.GetEnumerator();
        }

        public void Remove(string key)
        {
            if (_Source.ContainsKey(key))
            {
                _Source.Remove(key);
            }
            else
            {
                throw _Helper.ComposeItemNotExistsError(key);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
