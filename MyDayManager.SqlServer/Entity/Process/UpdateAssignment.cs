using MyDayManager.Entity.Convention;
using Sorschia.Data;
using Sorschia.Processing;
using System.Data.SqlClient;

namespace MyDayManager.Entity.Process
{
    internal sealed class UpdateAssignment : CoreEntityExecuteCallbackProcessBase<IAssignment, long>, IUpdateAssignment
    {
        public UpdateAssignment(IDbProcessor<SqlCommand> processor, IAssignmentParameters parameters) : base(processor)
        {
            _Parameters = parameters;
        }

        private readonly IAssignmentParameters _Parameters;
        public IAssignment Assignment { get; set; }

        protected override IDbQuery Query => DbQueryFactory.StoredProcedure(GetDbObjectName())
            .AddInParameter(_Parameters.Id, Assignment.Id)
            .AddInParameter(_Parameters.Title, Assignment.Title)
            .AddInParameter(_Parameters.Description, Assignment.Description)
            .AddInParameter(_Parameters.StatusId, Assignment.Status?.Id)
            .AddInParameter(_Parameters.Date, Assignment.Date);

        protected override IProcessResult<IAssignment> Callback(SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return ProcessResult<IAssignment>.Success(Assignment);
            }
            else
            {
                return ProcessResult<IAssignment>.Failed("Failed to update Assignment.");
            }
        }
    }
}
