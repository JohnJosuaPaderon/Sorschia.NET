namespace Sorschia.Events
{
    public sealed class WindowTitleBarTextEvent : SorschiaPubSubEventBase<string>
    {
        private bool ValidateTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title);
        }

        public void Change(string title)
        {
            if (ValidateTitle(title))
            {
                Raise(title);
            }
        }
    }
}
