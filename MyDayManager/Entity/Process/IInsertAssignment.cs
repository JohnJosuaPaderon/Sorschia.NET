using Sorschia.Processing;

namespace MyDayManager.Entity.Process
{
    public interface IInsertAssignment : IProcess<IAssignment>
    {
        IAssignment Assignment { get; set; }
    }
}
