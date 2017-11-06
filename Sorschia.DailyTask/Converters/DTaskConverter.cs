using Sorschia.DailyTask.Entities;
using Sorschia.DailyTask.EntityInfo;
using Sorschia.Data;
using Sorschia.Extensions;
using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.Converters
{
    public sealed class DTaskConverter : DbDataReaderConverterBase, IDTaskConverter
    {
        private readonly IDTaskFields _Fields;

        public DTaskConverter(
            IDbDataReaderToProcessResultConverter toProcessResultConverter,
            IDbDataReaderToEnumerableProcessResultConverter toEnumerableProcessResultConverter,
            IDTaskFields fields) : base(toProcessResultConverter, toEnumerableProcessResultConverter)
        {
            _Fields = fields;

            PId = new DbDataReaderConverterProperty<long>();
            PTitle = new DbDataReaderConverterProperty<string>();
            PDescription = new DbDataReaderConverterProperty<string>();
            PStatus = new DbDataReaderConverterProperty<DTaskStatus>();
            PScheduledDate = new DbDataReaderConverterProperty<DateTime>();
        }

        public IDbDataReaderConverterProperty<long> PId { get; }
        public IDbDataReaderConverterProperty<string> PTitle { get; }
        public IDbDataReaderConverterProperty<string> PDescription { get; }
        public IDbDataReaderConverterProperty<DTaskStatus> PStatus { get; }
        public IDbDataReaderConverterProperty<DateTime> PScheduledDate { get; }

        private IDTask Get(DbDataReader reader)
        {
            return new DTask()
            {
                Id = PId.TryGetValue(reader.GetInt64, _Fields.Id),
                Title = PTitle.TryGetValue(reader.GetString, _Fields.Title),
                Description = PDescription.TryGetValue(reader.GetString, _Fields.Description),
                ScheduledDate = PScheduledDate.TryGetValue(reader.GetDateTime, _Fields.ScheduledDate),
                Status = PStatus.TryGetValue(DTaskStatusParser.TryParse, reader.GetString(_Fields.Status))
            };
        }

        public IEnumerableProcessResult<IDTask> EnumerableFromReader(DbDataReader reader)
        {
            return _ToEnumerableProcessResultConverter.EnumerableFromReader(reader, Get);
        }

        public Task<IEnumerableProcessResult<IDTask>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            return _ToEnumerableProcessResultConverter.EnumerableFromReaderAsync(reader, Get);
        }

        public Task<IEnumerableProcessResult<IDTask>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            return _ToEnumerableProcessResultConverter.EnumerableFromReaderAsync(reader, cancellationToken, Get);
        }

        public IProcessResult<IDTask> FromReader(DbDataReader reader)
        {
            return _ToProcessResultConverter.FromReader(reader, Get);
        }

        public Task<IProcessResult<IDTask>> FromReaderAsync(DbDataReader reader)
        {
            return _ToProcessResultConverter.FromReaderAsync(reader, Get);
        }

        public Task<IProcessResult<IDTask>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            return _ToProcessResultConverter.FromReaderAsync(reader, Get);
        }
    }
}
