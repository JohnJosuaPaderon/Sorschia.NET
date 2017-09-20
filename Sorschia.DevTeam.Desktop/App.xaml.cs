﻿using System.Windows;

namespace Sorschia.DevTeam.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper.RunBootstrapper();
        }
    }
}
