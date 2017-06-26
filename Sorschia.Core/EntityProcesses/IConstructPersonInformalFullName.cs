using Sorschia.Core.Entities;

namespace Sorschia.Core.EntityProcesses
{
    public interface IConstructPersonInformalFullName : IDataProcess<string>
    {
        Person Person { get; set; }
    }
}
