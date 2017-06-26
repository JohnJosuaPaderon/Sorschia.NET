﻿using Sorschia.Core.EntityManagers;
using Sorschia.Core.EntityProcesses;
using Sorschia.Entities;

namespace Sorschia.Core.Entities
{
    public class Person : Entity<ulong>
    {
        static Person()
        {
            NameManager = new PersonNameManager(
                new ConstructPersonMiddleInitials());
        }

        public static IPersonNameManager NameManager { get; set; }

        private string _FirstName;
        private string _MiddleName;
        private string _MiddleInitials;
        private string _LastName;
        private string _NameSuffix;

        private bool MiddleInitialsRefreshRequired;
        private bool FullNameRefreshRequired;
        private bool InformalFullNameRefreshRequired;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                }
            }
        }

        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (_MiddleName != value)
                {
                    _MiddleName = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                    MiddleInitialsRefreshRequired = true;
                }
            }
        }

        public string MiddleInitials
        {
            get
            {
                if (MiddleInitialsRefreshRequired)
                {
                    var process = NameManager.ConstructMiddleInitials(this);

                    if (process.Status == ProcessResultStatus.Success)
                    {
                        _MiddleInitials = process.Data;
                        MiddleInitialsRefreshRequired = false;
                    }
                }

                return _MiddleInitials;
            }
        }
    }
}
