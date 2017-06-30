using Prism.Unity;
using Sorschia.Tests.Views;
using Sorschia.ViewModels;

namespace Sorschia.Tests
{
    class Bootstrapper : WindowsPcBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<SampleView>();

            MainWindowViewModel.InitialContent = nameof(SampleView);
        }
    }
}
