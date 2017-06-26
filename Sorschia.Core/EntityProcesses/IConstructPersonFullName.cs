using Sorschia.Core.Entities;

namespace Sorschia.Core.EntityProcesses
{
    public interface IConstructPersonFullName : IDataProcess<string>
    {
        Person Person { get; set; }
    }
}
