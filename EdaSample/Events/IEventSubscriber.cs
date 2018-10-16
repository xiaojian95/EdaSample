using System;
using System.Collections.Generic;
using System.Text;

namespace EdaSample.Events
{
    public interface IEventSubscriber
    {
        void Subscribe<TEvent, TEventHandler>() where TEvent : IEvents where TEventHandler : IEventHandler<TEvent>;
    }
}
