using Sorschia.DailyTask.Entities;
using Sorschia.Data;
using System;

namespace Sorschia.DailyTask.Converters
{
    public interface IDTaskConverter : IDbDataReaderConverter<IDTask>
    {
        IDbDataReaderConverterProperty<long> PId { get; }
        IDbDataReaderConverterProperty<string> PTitle { get; }
        IDbDataReaderConverterProperty<string> PDescription { get; }
        IDbDataReaderConverterProperty<DTaskStatus> PStatus { get; }
        IDbDataReaderConverterProperty<DateTime> PScheduledDate { get; }
    }
}
