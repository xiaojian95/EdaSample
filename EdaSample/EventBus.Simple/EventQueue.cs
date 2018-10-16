using EdaSample.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdaSample.EventBus.Simple
{
    internal sealed class EventQueue
    {
        public event EventHandler<EventProcessedEventArgs> EventPushed;

        public EventQueue() { }
        public void Push (IEvents events)
        {
            OnMessagePushed(new EventProcessedEventArgs(events));
        }
        private void OnMessagePushed(EventProcessedEventArgs e) => EventPushed?.Invoke(this, e);
    }
}
