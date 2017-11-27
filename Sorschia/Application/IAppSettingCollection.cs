using System.Collections.Generic;

namespace Sorschia.Application
{
    public interface IAppSettingCollection : IEnumerable<IAppSetting>
    {
        IAppSetting this[string key] { get; set; }
        void Add(IAppSetting setting);
        void Remove(string key);
        void Clear();
    }
}
