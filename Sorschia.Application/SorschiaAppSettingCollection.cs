using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Application
{
    internal sealed class SorschiaAppSettingCollection : ISorschiaAppSettingCollection
    {
        public SorschiaAppSettingCollection(ISorschiaApp owner)
        {
            Owner = owner;
            _Source = new Dictionary<string, ISorschiaAppSetting>();
            _Validator = SorschiaAppSettingCollectionValidator.Instance;
        }

        private readonly Dictionary<string, ISorschiaAppSetting> _Source;
        private readonly SorschiaAppSettingCollectionValidator _Validator;

        public ISorschiaApp Owner { get; }

        public object this[string name]
        {
            get
            {
                _Validator.ValidateName(name);

                if (_Source.ContainsKey(name))
                {
                    return _Source[name];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Validator.ValidateName(name);

                if (_Source.ContainsKey(name))
                {
                    _Source[name].Value = value;
                }
            }
        }

        public void Add(string name, object value)
        {
            _Validator.ValidateName(name);

            if (!_Source.ContainsKey(name))
            {
                var entry = new SorschiaAppSetting(name)
                {
                    Value = value
                };

                _Source.Add(name, entry);
            }
        }

        public IEnumerator<ISorschiaAppSetting> GetEnumerator()
        {
            return _Source.Values.GetEnumerator();
        }

        public void Remove(string name)
        {
            _Validator.ValidateName(name);

            if (_Source.ContainsKey(name))
            {
                _Source.Remove(name);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
