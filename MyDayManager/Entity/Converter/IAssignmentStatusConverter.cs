using Sorschia.Data;
using Sorschia.Entity.Converter;

namespace MyDayManager.Entity.Converter
{
    public interface IAssignmentStatusConverter : IEntityConverter<IAssignmentStatus, short>
    {
        IDbDataReaderConverterProperty<string> PDescription { get; }
    }
}
