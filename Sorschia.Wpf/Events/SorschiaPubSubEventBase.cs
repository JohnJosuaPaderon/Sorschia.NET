using Prism.Events;

namespace Sorschia.Events
{
    public abstract class SorschiaPubSubEventBase<T> : PubSubEvent<T>
    {
        public T Default { get; set; }
        
        public void Change(T payload)
        {
            Publish(payload);
        }

        public void Reset()
        {
            Publish(Default);
        }
    }
}
