using System.Collections.Generic;

namespace Sorschia.Application
{
    public interface IAppDirectoryCollection : IEnumerable<IAppDirectory>
    {
        IAppDirectory this[AppDirectoryType type] { get; set; }

        void Add(IAppDirectory directory);
        void Remove(AppDirectoryType type);
        void Clear();
    }
}
