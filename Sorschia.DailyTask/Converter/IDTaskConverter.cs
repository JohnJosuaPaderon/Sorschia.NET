using Sorschia.DailyTask.Entity;
using Sorschia.Data;
using Sorschia.Entity.Converter;
using System;

namespace Sorschia.DailyTask.Converter
{
    public interface IDTaskConverter : IEntityConverter<IDTask, long>
    {
        IDbDataReaderConverterProperty<string> PTitle { get; }
        IDbDataReaderConverterProperty<string> PDescription { get; }
        IDbDataReaderConverterProperty<DateTime> PScheduledDate { get; }
        IDbDataReaderConverterProperty<DTaskStatus> PStatus { get; }
    }
}
