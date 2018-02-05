using System.Collections.Generic;

namespace Sorschia.Application
{
    public interface ISorschiaAppSettingCollection : IEnumerable<ISorschiaAppSetting>
    {
        ISorschiaApp Owner { get; }
        object this[string name] { get; set; }
        void Add(string name, object value);
        void Remove(string name);
    }
}
