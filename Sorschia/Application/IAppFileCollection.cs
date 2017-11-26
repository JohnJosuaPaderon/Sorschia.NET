using System.Collections.Generic;

namespace Sorschia.Application
{
    public interface IAppFileCollection : IEnumerable<IAppFile>
    {
        IAppFile this[AppFileType type] { get;set; }

        void Add(IAppFile file);
        void Remove(AppFileType type);
        void Clear();
    }
}
