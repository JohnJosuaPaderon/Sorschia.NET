using Sorschia.DailyTask.Entities;
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
        private const string FIELD_ID = "Id";
        private const string FIELD_TITLE = "Title";
        private const string FIELD_DESCRIPTION = "Description";
        private const string FIELD_SCHEDULED_DATE = "ScheduledDate";
        private const string FIELD_STATUS = "Status";

        public DTaskConverter()
        {
            Def_Id = new DbDataReaderConverterProperty<long>();
            Def_Title = new DbDataReaderConverterProperty<string>();
            Def_Description = new DbDataReaderConverterProperty<string>();
            Def_Status = new DbDataReaderConverterProperty<DTaskStatus>();
            Def_ScheduledDate = new DbDataReaderConverterProperty<DateTime>();
        }

        public IDbDataReaderConverterProperty<long> Def_Id { get; }
        public IDbDataReaderConverterProperty<string> Def_Title { get; }
        public IDbDataReaderConverterProperty<string> Def_Description { get; }
        public IDbDataReaderConverterProperty<DTaskStatus> Def_Status { get; }
        public IDbDataReaderConverterProperty<DateTime> Def_ScheduledDate { get; }

        private IDTask Get(DbDataReader reader)
        {
            return new DTask()
            {
                Id = Def_Id.TryGetValue(reader.GetInt64, FIELD_ID),
                Title = Def_Title.TryGetValue(reader.GetString, FIELD_TITLE),
                Description = Def_Title.TryGetValue(reader.GetString, FIELD_DESCRIPTION),
                ScheduledDate = Def_ScheduledDate.TryGetValue(reader.GetDateTime, FIELD_SCHEDULED_DATE),
                Status = Def_Status.TryGetValue(DTaskStatusParser.TryParse, reader.GetString(FIELD_STATUS))
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
