using System.Windows;
using Prism.Unity;
using Sorschia.Views;

namespace Sorschia
{
    public class WindowsPcBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
