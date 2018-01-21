using MyDayManager.Entity.Convention;
using MyDayManager.Entity.Converter;
using Sorschia.Data;
using System.Data.SqlClient;

namespace MyDayManager.Entity.Process
{
    internal sealed class GetAssignmentStatusByKey : CoreEntityReadProcessBase<IAssignmentStatus, short, IAssignmentStatusConverter>, IGetAssignmentStatusByKey
    {
        public GetAssignmentStatusByKey(IDbProcessor<SqlCommand> processor, IAssignmentStatusConverter converter, IGlobalEntityParameters parameters) : base(processor, converter)
        {
            _Parameters = parameters;
        }

        private readonly IGlobalEntityParameters _Parameters;

        public string Key { get; set; }

        protected override IDbQuery Query =>
            DbQueryFactory.StoredProcedure(GetDbObjectName())
            .AddInParameter(_Parameters.Key, Key);
    }
}
