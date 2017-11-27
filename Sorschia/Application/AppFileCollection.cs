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
            _Source = new Dictionary<AppFileType, IAppFile>();
        }

        private readonly Dictionary<AppFileType, IAppFile> _Source;
        private readonly AppFileCollectionHelper _Helper;

        public IAppFile this[AppFileType type]
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

        public void Add(IAppFile file)
        {
            _Helper.ValidateFile(file);

            if (_Source.ContainsKey(file.Type))
            {
                throw _Helper.ComposeItemDuplicationError(file.Type);
            }
            else
            {
                _Source.Add(file.Type, file);
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

        public void Remove(AppFileType type)
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
