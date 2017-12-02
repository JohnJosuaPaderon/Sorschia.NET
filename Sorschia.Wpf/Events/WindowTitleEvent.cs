using Prism.Events;

namespace Sorschia.Events
{
    public sealed class WindowTitleEvent : PubSubEvent<string>
    {
        public void Change(string title)
        {
            Publish(title);
        }
    }
}
