using Sorschia.DailyTask.Entities;
using Sorschia.Data;
using System;

namespace Sorschia.DailyTask.EntityConverters
{
    public interface IDTaskConverter : IDbDataReaderConverter<IDTask>
    {
        IDbDataReaderConverterProperty<long> Def_Id { get; }
        IDbDataReaderConverterProperty<string> Def_Title { get; }
        IDbDataReaderConverterProperty<string> Def_Description { get; }
        IDbDataReaderConverterProperty<DTaskStatus> Def_Status { get; }
        IDbDataReaderConverterProperty<DateTime> Def_ScheduledDate { get; }
    }
}
