namespace Sorschia.Convention
{
    partial class NameBase
    {
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

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                }
            }
        }

        public string NameExtension
        {
            get { return _NameExtension; }
            set
            {
                if (_NameExtension != value)
                {
                    _NameExtension = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                }
            }
        }

        public string FullName
        {
            get
            {
                if (FullNameRefreshRequired)
                {
                    _FullName = _FullNameBuilder.Build(LastName, FirstName, NameExtension, MiddleName);
                    FullNameRefreshRequired = false;
                }

                return _FullName;
            }
        }

        public string InformalFullName
        {
            get
            {
                if (InformalFullNameRefreshRequired)
                {
                    _InformalFullName = _InformalFullNameBuilder.Build(FirstName, MiddleInitials, LastName, NameExtension);
                    InformalFullNameRefreshRequired = false;
                }

                return _InformalFullName;
            }
        }

        public string MiddleInitials
        {
            get
            {
                if (MiddleInitialsRefreshRequired)
                {
                    _MiddleInitials = _AcronymBuilder.Build(MiddleName);
                    MiddleInitialsRefreshRequired = false;
                }

                return _MiddleInitials;
            }
        }
    }
}
