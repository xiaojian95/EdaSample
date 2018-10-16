using System;
using System.Collections.Generic;
using System.Text;

namespace EdaSample.Events
{
    public interface IEventBus:IEventSubscriber,IEventPublisher
    {

    }
}
