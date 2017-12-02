using Prism.Interactivity;
using System.Windows;
using System.Windows.Media;

namespace Sorschia.ViewModels
{
    public class CustomPopupWindowAction : PopupWindowAction
    {
        protected override Window CreateWindow()
        {
            return new Window()
            {
                SizeToContent = SizeToContent.WidthAndHeight,
                //ShowTitleBar = false,
                //ShowMinButton = false,
                //ShowMaxRestoreButton = false,
                //ShowCloseButton = false,
                WindowStartupLocation = WindowStartupLocation ?? System.Windows.WindowStartupLocation.CenterScreen,
                BorderBrush = new SolidColorBrush(Color.FromArgb(50, 0, 0, 0)),
                BorderThickness = new Thickness(1),
                Padding = new Thickness(50)
            };
        }
    }
}
