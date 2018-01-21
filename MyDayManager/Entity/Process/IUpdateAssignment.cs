using Sorschia.Processing;

namespace MyDayManager.Entity.Process
{
    public interface IUpdateAssignment : IProcess<IAssignment>
    {
        IAssignment Assignment { get; set; }
    }
}
