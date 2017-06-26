using System.Text;
using Sorschia.Core.Entities;

namespace Sorschia.Core.EntityProcesses
{
    internal sealed class ConstructPersonMiddleInitials : IConstructPersonMiddleInitials
    {
        public Person Person { get; set; }

        public void Dispose()
        {
            Person = null;
        }

        public IDataProcessResult<string> Execute()
        {
            string data = null;
            ProcessResultStatus status = ProcessResultStatus.Undefined;
            string message = null;

            Validate(ref status, ref message);

            Person = null;
            return new DataProcessResult<string>(data, status, message);
        }

        private void Validate(ref ProcessResultStatus status, ref string message)
        {
            if (Person == null)
            {
                status = ProcessResultStatus.Failed;
                message = $"{nameof(Person)} is null.";
            }
            else if (string.IsNullOrWhiteSpace(Person.MiddleName))
            {
                status = ProcessResultStatus.Failed;
                message = $"{nameof(Person)}.{nameof(Person.MiddleName)} is null or white space.";
            }
        }

        private string Construct()
        {
            var builder = new StringBuilder();

            var splittedMiddleName = Person.MiddleName.Split(' ');

            foreach (var item in splittedMiddleName)
            {
                AppendChar(builder, item);
            }

            return builder.ToString();
        }

        private static void AppendChar(StringBuilder builder, string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                var c = char.IsLetter(item[0]);
                builder.Append(c);
            }
        }
    }
}
