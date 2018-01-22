using MyDayManager.Entity.Convention;
using Sorschia.Data;
using Sorschia.Processing;
using System.Data.SqlClient;

namespace MyDayManager.Entity.Process
{
    internal sealed class InsertAssignment : CoreEntityExecuteCallbackProcessBase<IAssignment, long>, IInsertAssignment
    {
        public InsertAssignment(IDbProcessor<SqlCommand> processor, IAssignmentParameters parameters) : base(processor)
        {
            _Parameters = parameters;
        }

        private readonly IAssignmentParameters _Parameters;
        public IAssignment Assignment { get; set; }

        protected override IDbQuery Query => DbQueryFactory.StoredProcedure(GetDbObjectName())
            .AddOutParameter(_Parameters.Id, DbQueryParameterType.Int64)
            .AddInParameter(_Parameters.Title, Assignment.Title)
            .AddInParameter(_Parameters.Description, Assignment.Description)
            .AddInParameter(_Parameters.StatusId, Assignment.Status?.Id)
            .AddInParameter(_Parameters.Date, Assignment.Date);

        protected override IProcessResult<IAssignment> Callback(SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                Assignment.Id = command.Parameters.GetInt64(_Parameters.Id);
                return ProcessResult<IAssignment>.Success(Assignment);
            }
            else
            {
                return ProcessResult<IAssignment>.Failed("Failed to insert Assignment.");
            }
        }
    }
}
