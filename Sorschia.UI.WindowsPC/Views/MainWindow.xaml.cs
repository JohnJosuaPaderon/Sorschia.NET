﻿using MahApps.Metro.Controls;
using Sorschia.ViewModels;

namespace Sorschia.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => ViewModel.Load();
        }

        public MainWindowViewModel ViewModel => DataContext as MainWindowViewModel;
    }
}
