using Sorschia.Data;

namespace Sorschia.Entity.Converter
{
    public abstract class EntityConverterBase<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        public EntityConverterBase()
        {
            PId = new DbDataReaderConverterProperty<TIdentifier>();
        }

        public IDbDataReaderConverterProperty<TIdentifier> PId { get; }
    }
}
