using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Application
{
    public sealed class AppSettingCollection : IAppSettingCollection
    {
        public static AppSettingCollection Empty => new AppSettingCollection();

        public AppSettingCollection()
        {
            _Helper = AppSettingCollectionHelper.Instance;
            _Source = new Dictionary<string, IAppSetting>();
        }

        private readonly AppSettingCollectionHelper _Helper;
        private readonly Dictionary<string, IAppSetting> _Source;

        public IAppSetting this[string key]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw _Helper.ComposeParameterRequiredError(nameof(key));
                }
                else if (!_Source.ContainsKey(key))
                {
                    throw _Helper.ComposeItemNotExistsError(key);
                }
                else
                {
                    return _Source[key];
                }
            }
            set
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw _Helper.ComposeParameterRequiredError(nameof(key));
                }
                else if (!_Source.ContainsKey(key))
                {
                    throw _Helper.ComposeItemNotExistsError(key);
                }
                else
                {
                    _Source[key] = value;
                }
            }
        }

        public void Add(IAppSetting setting)
        {
            if (string.IsNullOrWhiteSpace(setting.Key))
            {
                throw _Helper.ComposeParameterRequiredError(nameof(setting.Key));
            }
            else if (_Source.ContainsKey(setting.Key))
            {
                throw _Helper.ComposeItemDuplicationError(setting.Key);
            }
            else
            {
                _Source.Add(setting.Key, setting);
            }
        }

        public void Clear()
        {
            _Source.Clear();
        }

        public IEnumerator<IAppSetting> GetEnumerator()
        {
            return _Source.Values.GetEnumerator();
        }

        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw _Helper.ComposeParameterRequiredError(nameof(key));
            }
            else if (!_Source.ContainsKey(key))
            {
                throw _Helper.ComposeItemNotExistsError(key);
            }
            else
            {
                _Source.Remove(key);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
