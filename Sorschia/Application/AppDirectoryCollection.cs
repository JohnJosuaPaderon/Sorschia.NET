using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Application
{
    public sealed class AppDirectoryCollection : IAppDirectoryCollection
    {

        public AppDirectoryCollection()
        {
            _Helper = AppDirectoryCollectionHelper.Instance;
            _Source = new Dictionary<AppDirectoryType, IAppDirectory>();
        }

        private readonly AppDirectoryCollectionHelper _Helper;
        private readonly Dictionary<AppDirectoryType, IAppDirectory> _Source;

        public IAppDirectory this[AppDirectoryType type]
        {
            get
            {
                if (_Source.ContainsKey(type))
                {
                    return _Source[type];
                }
                else
                {
                    throw _Helper.ComposeItemNotExistsError(type);
                }
            }
            set
            {
                if (_Source.ContainsKey(type))
                {
                    _Source[type] = value;
                }
                else
                {
                    throw _Helper.ComposeItemNotExistsError(type);
                }
            }
        }

        public void Add(IAppDirectory directory)
        {
            _Helper.ValidateDirectory(directory);

            if (_Source.ContainsKey(directory.Type))
            {
                throw _Helper.ComposeItemDuplicationError(directory.Type);
            }
            else
            {
                _Source.Add(directory.Type, directory);
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

        public void Remove(AppDirectoryType type)
        {
            if (_Source.ContainsKey(type))
            {
                _Source.Remove(type);
            }
            else
            {
                throw _Helper.ComposeItemNotExistsError(type);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
