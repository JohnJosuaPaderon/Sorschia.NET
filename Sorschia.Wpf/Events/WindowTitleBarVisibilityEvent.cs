using System.Windows;

namespace Sorschia.Events
{
    public sealed class WindowTitleBarVisibilityEvent : SorschiaPubSubEventBase<Visibility>
    {
        void Show()
        {
            Change(Visibility.Visible);
        }

        void Collapse()
        {
            Change(Visibility.Collapsed);
        }

        void Hide()
        {
            Change(Visibility.Hidden);
        }
    }
}
