using Prism.Unity;
using Sorschia.DailyTask.Views;
using System.Windows;

namespace Sorschia.DailyTask
{
    class Bootstrapper : UnityBootstrapper
    {
        static Bootstrapper()
        {
            Current = new Bootstrapper();
        }

        public static Bootstrapper Current { get; }

        public static void RunBootstrapper()
        {
            Current.Run();
        }

        private Bootstrapper()
        {

        }

        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            System.Windows.Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
    }
}
