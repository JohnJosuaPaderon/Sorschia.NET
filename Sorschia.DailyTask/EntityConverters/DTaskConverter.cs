using Sorschia.DailyTask.Entities;
using Sorschia.DailyTask.EntityInfo;
using Sorschia.Data;
using Sorschia.Extensions;
using Sorschia.Processing;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.EntityConverters
{
    public sealed class DTaskConverter : IDTaskConverter
    {
        public DTaskConverter(IDTaskFields fields)
        {
            _Fields = fields;

            PId = new DbDataReaderConverterProperty<long>();
            PTitle = new DbDataReaderConverterProperty<string>();
            PDescription = new DbDataReaderConverterProperty<string>();
            PStatus = new DbDataReaderConverterProperty<DTaskStatus>();
            PScheduledDate = new DbDataReaderConverterProperty<DateTime>();
        }

        private readonly IDTaskFields _Fields;

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
            try
            {
                var list = new List<IDTask>();

                while (reader.Read())
                {
                    list.Add(Get(reader));
                }

                return EnumerableProcessResult<IDTask>.Success(list);
            }
            catch (Exception ex)
            {
                return EnumerableProcessResult<IDTask>.Failed(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDTask>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IDTask>();

                while (await reader.ReadAsync())
                {
                    list.Add(Get(reader));
                }

                return EnumerableProcessResult<IDTask>.Success(list);
            }
            catch (Exception ex)
            {
                return EnumerableProcessResult<IDTask>.Failed(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDTask>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IDTask>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(Get(reader));
                }

                return EnumerableProcessResult<IDTask>.Success(list);
            }
            catch (Exception ex)
            {
                return EnumerableProcessResult<IDTask>.Failed(ex);
            }
        }

        public IProcessResult<IDTask> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return ProcessResult<IDTask>.Success(Get(reader));
            }
            catch (Exception ex)
            {
                return ProcessResult<IDTask>.Failed(ex);
            }
        }

        public async Task<IProcessResult<IDTask>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return ProcessResult<IDTask>.Success(Get(reader));
            }
            catch (Exception ex)
            {
                return ProcessResult<IDTask>.Failed(ex);
            }
        }

        public async Task<IProcessResult<IDTask>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return ProcessResult<IDTask>.Success(Get(reader));
            }
            catch (Exception ex)
            {
                return ProcessResult<IDTask>.Failed(ex);
            }
        }
    }
}
