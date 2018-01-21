using MyDayManager.Entity.Convention;
using MyDayManager.Entity.Converter;
using Sorschia.Data;
using System.Data.SqlClient;

namespace MyDayManager.Entity.Process
{
    internal sealed class GetAssignmentStatus : CoreEntityReadProcessBase<IAssignmentStatus, short, IAssignmentStatusConverter>, IGetAssignmentStatus
    {
        public GetAssignmentStatus(IDbProcessor<SqlCommand> processor, IAssignmentStatusParameters parameters, IAssignmentStatusConverter converter) : base(processor, converter)
        {
            _Parameters = parameters;
        }

        private readonly IAssignmentStatusParameters _Parameters;
        public short Id { get; set; }

        protected override IDbQuery Query =>
            DbQueryFactory.StoredProcedure(GetDbObjectName())
            .AddInParameter(_Parameters.Id, Id);

        protected override void PrepareConverter(IAssignmentStatusConverter converter)
        {
            converter.PId.Value = Id;
        }
    }
}
