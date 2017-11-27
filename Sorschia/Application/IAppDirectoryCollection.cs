using System.Collections.Generic;

namespace Sorschia.Application
{
    public interface IAppDirectoryCollection : IEnumerable<IAppDirectory>
    {
        IAppDirectory this[string key] { get; set; }

        void Add(IAppDirectory directory);
        void Remove(string key);
        void Clear();
    }
}
