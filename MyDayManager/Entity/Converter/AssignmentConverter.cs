using MyDayManager.Entity.Convention;
using MyDayManager.Entity.Manager;
using Sorschia.Data;
using Sorschia.Entity.Converter;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace MyDayManager.Entity.Converter
{
    internal sealed class AssignmentConverter : EntityConverterBase<IAssignment, long>, IAssignmentConverter
    {
        public AssignmentConverter(IAssignmentFields fields, IAssignmentStatusManager statusManager)
        {
            _Fields = fields;
            _StatusManager = statusManager;

            PTitle = new DbDataReaderConverterProperty<string>();
            PDescription = new DbDataReaderConverterProperty<string>();
            PStatus = new DbDataReaderConverterProperty<IAssignmentStatus>();
            PDate = new DbDataReaderConverterProperty<DateTime>();
        }

        private readonly IAssignmentFields _Fields;
        private readonly IAssignmentStatusManager _StatusManager;

        public IDbDataReaderConverterProperty<string> PTitle { get; }
        public IDbDataReaderConverterProperty<string> PDescription { get; }
        public IDbDataReaderConverterProperty<IAssignmentStatus> PStatus { get; }
        public IDbDataReaderConverterProperty<DateTime> PDate { get; }

        private IAssignment Convert(DbDataReader reader, IAssignmentStatus status)
        {
            return new Assignment
            {
                Id = PId.TryGetValue(reader.GetInt64, _Fields.Id),
                Title = PTitle.TryGetValue(reader.GetString, _Fields.Title),
                Description = PDescription.TryGetValue(reader.GetString, _Fields.Description),
                Status = status,
                Date = PDate.TryGetValue(reader.GetDateTime, _Fields.Date)
            };
        }

        protected override IAssignment Convert(DbDataReader reader)
        {
            var status = PStatus.TryGetValueFromProcess(_StatusManager.Get, reader.GetInt16, _Fields.StatusId);
            return Convert(reader, status);
        }

        protected override async Task<IAssignment> ConvertAsync(DbDataReader reader)
        {
            var status = await PStatus.TryGetValueFromProcessAsync(_StatusManager.GetAsync, reader.GetInt16, _Fields.StatusId);
            return Convert(reader, status);
        }

        protected override async Task<IAssignment> ConvertAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var status = await PStatus.TryGetValueFromProcessAsync(_StatusManager.GetAsync, reader.GetInt16, _Fields.StatusId, cancellationToken);
            return Convert(reader, status);
        }
    }
}
