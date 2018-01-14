using Prism.Events;

namespace Sorschia.Events
{
    public abstract class SorschiaPubSubEventBase<T> : PubSubEvent<T>
    {
        public T Default { get; set; }
        
        public void Raise(T payload)
        {
            if (!Equals(default(T), payload))
            {
                Publish(payload);
            }
        }

        public void Reset()
        {
            Publish(Default);
        }
    }
}
