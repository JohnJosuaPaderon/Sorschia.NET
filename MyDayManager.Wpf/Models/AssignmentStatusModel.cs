using MyDayManager.Entity;
using Sorschia.Models;

namespace MyDayManager.Models
{
    internal sealed class AssignmentStatusModel : EntityModelBase<IAssignmentStatus, short>
    {
        public static AssignmentStatusModel TryInitialize(IAssignmentStatus source)
        {
            return source != null ? new AssignmentStatusModel(source) : null;
        }

        public AssignmentStatusModel(IAssignmentStatus source) : base(source)
        {
            Description = source.Description;
        }

        public string Description { get; }

        public override IAssignmentStatus GetSource()
        {
            return base.GetSource();
        }
    }
}