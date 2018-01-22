using MyDayManager.Entity.Convention;
using Sorschia.Data;
using Sorschia.Entity.Converter;
using System.Data.Common;

namespace MyDayManager.Entity.Converter
{
    internal sealed class AssignmentStatusConverter : EntityConverterBase<IAssignmentStatus, short>, IAssignmentStatusConverter
    {
        public AssignmentStatusConverter(IAssignmentStatusFields fields)
        {
            _Fields = fields;
            PDescription = new DbDataReaderConverterProperty<string>();
        }

        private readonly IAssignmentStatusFields _Fields;
        public IDbDataReaderConverterProperty<string> PDescription { get; private set; }

        protected override IAssignmentStatus Convert(DbDataReader reader)
        {
            return new AssignmentStatus(PDescription.TryGetValue(reader.GetString(_Fields.Description)))
            {
                Id = PId.TryGetValue(reader.GetInt16(_Fields.Id))
            };
        }

        public override void Dispose()
        {
            base.Dispose();
            PDescription = null;
        }
    }
}
