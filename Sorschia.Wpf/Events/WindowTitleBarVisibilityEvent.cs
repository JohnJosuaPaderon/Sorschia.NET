using System.Windows;

namespace Sorschia.Events
{
    public sealed class WindowTitleBarVisibilityEvent : SorschiaPubSubEventBase<Visibility>
    {
        public void Show()
        {
            Raise(Visibility.Visible);
        }

        public void Collapse()
        {
            Raise(Visibility.Collapsed);
        }

        public void Hide()
        {
            Raise(Visibility.Hidden);
        }
    }
}
