using Sorschia.Convention;

namespace MyDayManager.Entity.Convention
{
    internal sealed class AssignmentStatusFields : EntityFieldsBase, IAssignmentStatusFields
    {
        public AssignmentStatusFields(IEntityFieldFormatter formatter) : base(formatter)
        {
            Description = formatter.Format(nameof(Description));
        }

        public string Description { get; }
    }
}
