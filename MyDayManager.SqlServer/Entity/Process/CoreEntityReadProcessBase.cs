using Sorschia.Data;
using Sorschia.Entity;
using Sorschia.Entity.Converter;
using Sorschia.Entity.Process;
using System.Data.SqlClient;

namespace MyDayManager.Entity.Process
{
    public abstract class CoreEntityReadProcessBase<T, TIdentifier, TConverter> : SqlEntityReadProcessBase<T, TIdentifier, TConverter>
        where T : IEntity<TIdentifier>
        where TConverter : IEntityConverter<T, TIdentifier>
    {
        public CoreEntityReadProcessBase(IDbProcessor<SqlCommand> processor, TConverter converter) : base(processor, converter)
        {
        }
    }
}
