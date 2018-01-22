using Sorschia.Data;

namespace Sorschia.Entity.Converter
{
    public abstract class EntityConverterBase<T, TIdentifier> : DbDataReaderConverterBase<T>
        where T : IEntity<TIdentifier>
    {
        public EntityConverterBase()
        {
            PId = new DbDataReaderConverterProperty<TIdentifier>();
        }

        public IDbDataReaderConverterProperty<TIdentifier> PId { get; private set; }

        public virtual void Dispose()
        {
            PId = null;
        }
    }
}
