using Sorschia.Data;
using Sorschia.Entity;
using Sorschia.Entity.Converter;
using Sorschia.Entity.Process;
using System.Data.SqlClient;

namespace MyDayManager.Entity.Process
{
    public abstract class CoreEntityReadEnumerableProcessBase<T, TIdentifier, TConverter> : SqlEntityReadEnumerableProcessBase<T, TIdentifier, TConverter>
        where T : IEntity<TIdentifier>
        where TConverter : IEntityConverter<T, TIdentifier>
    {
        public CoreEntityReadEnumerableProcessBase(IDbProcessor<SqlCommand> processor, TConverter converter) : base(processor, converter)
        {
        }
    }
}
