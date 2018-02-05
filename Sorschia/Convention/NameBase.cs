namespace Sorschia.Convention
{
    public abstract partial class NameBase
    {
        static NameBase()
        {
        }

        private static readonly IAcronymBuilder _AcronymBuilder;
        private static readonly IFullNameBuilder _FullNameBuilder;
        private static readonly IInformalFullNameBuilder _InformalFullNameBuilder;

        private bool FullNameRefreshRequired;
        private bool InformalFullNameRefreshRequired;
        private bool MiddleInitialsRefreshRequired;

        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private string _NameExtension;
        private string _FullName;
        private string _InformalFullName;
        private string _MiddleInitials;
    }
}
