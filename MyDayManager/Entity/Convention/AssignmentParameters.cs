using Sorschia.Convention;

namespace MyDayManager.Entity.Convention
{
    internal sealed class AssignmentParameters : EntityParametersBase, IAssignmentParameters
    {
        public AssignmentParameters(IEntityParameterFormatter formatter) : base(formatter)
        {
            Title = formatter.Format(nameof(Title));
            Description = formatter.Format(nameof(Description));
            StatusId = formatter.Format(nameof(StatusId));
            Date = formatter.Format(nameof(Date));
        }

        public string Title { get; }
        public string Description { get; }
        public string StatusId { get; }
        public string Date { get; }
    }
}
