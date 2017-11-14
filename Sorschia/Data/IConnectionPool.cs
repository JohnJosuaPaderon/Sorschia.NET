using System;
using System.Data.Common;

namespace Sorschia.Data
{
    public interface IConnectionPool<T>
        where T : DbConnection
    {
        T this[Guid guid] { get; set; }
    }
}
