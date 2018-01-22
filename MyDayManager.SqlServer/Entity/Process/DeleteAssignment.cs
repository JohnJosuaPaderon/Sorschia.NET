using MyDayManager.Entity.Convention;
using Sorschia.Data;
using Sorschia.Processing;
using System.Data.SqlClient;

namespace MyDayManager.Entity.Process
{
    internal sealed class DeleteAssignment : CoreEntityExecuteCallbackProcessBase<IAssignment, long>, IDeleteAssignment
    {
        public DeleteAssignment(IDbProcessor<SqlCommand> processor, IAssignmentParameters parameters) : base(processor)
        {
            _Parameters = parameters;
        }

        private readonly IAssignmentParameters _Parameters;
        public IAssignment Assignment { get; set; }

        protected override IDbQuery Query => DbQueryFactory.StoredProcedure(GetDbObjectName())
            .AddInParameter(_Parameters.Id, Assignment.Id);

        protected override IProcessResult<IAssignment> Callback(SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return ProcessResult<IAssignment>.Success(Assignment);
            }
            else
            {
                return ProcessResult<IAssignment>.Failed("Failed to delete Assignment.");
            }
        }
    }
}
