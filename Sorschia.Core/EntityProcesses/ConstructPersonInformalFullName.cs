﻿using Sorschia.Core.Entities;
using System.Text;

namespace Sorschia.Core.EntityProcesses
{
    internal sealed class ConstructPersonInformalFullName : IConstructPersonInformalFullName
    {
        public Person Person { get; set; }

        public IDataProcessResult<string> Execute()
        {
            string data = null;
            ProcessResultStatus status = ProcessResultStatus.Undefined;
            string message = null;

            if (Person == null)
            {
                status = ProcessResultStatus.Failed;
                message = "Person is null.";
            }
            else
            {
                var hasFirstName = HasValue(Person.FirstName);
                var hasMiddleInitials = HasValue(Person.MiddleInitials);
                var hasLastName = HasValue(Person.LastName);
                var hasNameSuffix = HasValue(Person.NameSuffix);

                if (hasLastName || hasFirstName || hasMiddleInitials || hasNameSuffix)
                {
                    var builder = new StringBuilder();

                    if (hasFirstName)
                    {
                        builder.Append(Person.FirstName.Trim());

                        if (hasMiddleInitials || hasLastName || hasNameSuffix)
                        {
                            builder.Append(" ");
                        }
                    }

                    if (hasMiddleInitials)
                    {
                        builder.Append(Person.MiddleInitials.Trim());

                        if (hasLastName || hasNameSuffix)
                        {
                            builder.Append(" ");
                        }
                    }

                    if (hasLastName)
                    {
                        builder.Append(Person.LastName.Trim());

                        if (hasNameSuffix)
                        {
                            builder.Append(" ");
                        }
                    }

                    if (hasNameSuffix)
                    {
                        builder.Append(Person.NameSuffix.Trim());
                    }

                    status = ProcessResultStatus.Success;
                    data = builder.ToString();
                }
                else
                {
                    status = ProcessResultStatus.Failed;
                    message = "Informal full name cannot be constructed.";
                }
            }

            return new DataProcessResult<string>(data, status, message);
        }

        private static bool HasValue(string arg)
        {
            return !string.IsNullOrWhiteSpace(arg);
        }
    }
}
