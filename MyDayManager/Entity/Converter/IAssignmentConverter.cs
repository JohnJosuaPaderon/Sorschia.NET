using Sorschia.Data;
using Sorschia.Entity.Converter;
using System;

namespace MyDayManager.Entity.Converter
{
    public interface IAssignmentConverter : IEntityConverter<IAssignment, long>
    {
        IDbDataReaderConverterProperty<string> PTitle { get; }
        IDbDataReaderConverterProperty<string> PDescription { get; }
        IDbDataReaderConverterProperty<IAssignmentStatus> PStatus { get; }
        IDbDataReaderConverterProperty<DateTime> PDate { get; }
    }
}
