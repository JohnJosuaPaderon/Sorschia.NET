using System.Collections.Generic;

namespace Sorschia.Application
{
    public interface IAppFileCollection : IEnumerable<IAppFile>
    {
        IAppFile this[string key] { get; set; }

        void Add(IAppFile file);
        void Remove(string key);
        void Clear();
    }
}
