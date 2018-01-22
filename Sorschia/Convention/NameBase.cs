using Sorschia.Application;

namespace Sorschia.Convention
{
    public abstract partial class NameBase
    {
        static NameBase()
        {
            _AcronymBuilder = SorschiaApp.GetService<IAcronymBuilder>();
            _FullNameBuilder = SorschiaApp.GetService<IFullNameBuilder>();
            _InformalFullNameBuilder = SorschiaApp.GetService<IInformalFullNameBuilder>();
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
