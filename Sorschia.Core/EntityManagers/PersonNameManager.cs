using System;
using Sorschia.Core.Entities;
using Sorschia.Core.EntityProcesses;

namespace Sorschia.Core.EntityManagers
{
    public class PersonNameManager : IPersonNameManager
    {
        private IConstructPersonMiddleInitials ConstructPersonMiddleInitials { get; }
        private IConstructPersonFullName ConstructPersonFullName { get; }
        private IConstructPersonInformalFullName ConstructPersonInformalFullName { get; }

        public PersonNameManager(IConstructPersonFullName constructPersonFullName, IConstructPersonInformalFullName constructPersonInformalFullName, IConstructPersonMiddleInitials constructPersonMiddleInitials)
        {
            ConstructPersonFullName = constructPersonFullName;
            ConstructPersonInformalFullName = constructPersonInformalFullName;
            ConstructPersonMiddleInitials = constructPersonMiddleInitials;
        }

        public IDataProcessResult<string> ConstructFullName(Person person)
        {
            ConstructPersonFullName.Person = person;
            return ConstructPersonFullName.Execute();
        }

        public IDataProcessResult<string> ConstructInformalFullName(Person person)
        {
            throw new NotImplementedException();
        }

        public IDataProcessResult<string> ConstructMiddleInitials(Person person)
        {
            ConstructPersonMiddleInitials.Person = person;
            return ConstructPersonMiddleInitials.Execute();
        }
    }
}
