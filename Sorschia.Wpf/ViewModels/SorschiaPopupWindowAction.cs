using MahApps.Metro.Controls;
using Prism.Interactivity;
using System.Windows;
using System.Windows.Media;

namespace Sorschia.ViewModels
{
    public class SorschiaPopupWindowAction : PopupWindowAction
    {
        protected override Window CreateWindow()
        {
            return new MetroWindow()
            {
                SizeToContent = SizeToContent.WidthAndHeight,
                ShowTitleBar = false,
                ShowMinButton = false,
                ShowMaxRestoreButton = false,
                ShowCloseButton = false,
                WindowStartupLocation = WindowStartupLocation ?? System.Windows.WindowStartupLocation.CenterOwner,
                BorderBrush = new SolidColorBrush(Color.FromArgb(50, 0, 0, 0)),
                BorderThickness = new Thickness(1)
            };
        }
    }
}
