using Sorschia.DailyTask.Entity;
using Sorschia.Data;
using Sorschia.Entity.Converter;
using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.Converters
{
    public sealed class DTaskConverter : EntityConverterBase<IDTask, long>, IDTaskConverter
    {
        public DTaskConverter()
        {
            PTitle = new DbDataReaderConverterProperty<string>();
            PDescription = new DbDataReaderConverterProperty<string>();
            PScheduledDate = new DbDataReaderConverterProperty<DateTime>();
            PStatus = new DbDataReaderConverterProperty<DTaskStatus>();
        }

        public IDbDataReaderConverterProperty<string> PTitle { get; }
        public IDbDataReaderConverterProperty<string> PDescription { get; }
        public IDbDataReaderConverterProperty<DateTime> PScheduledDate { get; }
        public IDbDataReaderConverterProperty<DTaskStatus> PStatus { get; }

        private IDTask Get(DbDataReader reader)
        {
            return new DTask()
            {
                Id = PId.TryGetValue(1)
            };
        }

        public IEnumerableProcessResult<IDTask> EnumerableFromReader(DbDataReader reader)
        {
            return EnumerableFromReader(reader, Get);
        }

        public Task<IEnumerableProcessResult<IDTask>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<IDTask>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IProcessResult<IDTask> FromReader(DbDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<IDTask>> FromReaderAsync(DbDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<IDTask>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
