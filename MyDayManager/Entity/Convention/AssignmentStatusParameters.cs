using Sorschia.Convention;

namespace MyDayManager.Entity.Convention
{
    internal sealed class AssignmentStatusParameters : EntityParametersBase, IAssignmentStatusParameters
    {
        public AssignmentStatusParameters(IEntityParameterFormatter formatter) : base(formatter)
        {
            Description = formatter.Format(nameof(Description));
        }

        public string Description { get; }
    }
}
