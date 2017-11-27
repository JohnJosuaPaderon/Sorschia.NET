using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Application
{
    public sealed class AppFileCollection : IAppFileCollection
    {
        public static AppFileCollection Empty => new AppFileCollection();

        public AppFileCollection()
        {
            _Helper = AppFileCollectionHelper.Instance;
            _Source = new Dictionary<string, IAppFile>();
        }

        private readonly Dictionary<string, IAppFile> _Source;
        private readonly AppFileCollectionHelper _Helper;

        public IAppFile this[string key]
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

        public void Add(IAppFile file)
        {
            _Helper.ValidateFile(file);

            if (_Source.ContainsKey(file.Key))
            {
                throw _Helper.ComposeItemDuplicationError(file.Key);
            }
            else
            {
                _Source.Add(file.Key, file);
            }
        }

        public void Clear()
        {
            _Source.Clear();
        }

        public IEnumerator<IAppFile> GetEnumerator()
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
