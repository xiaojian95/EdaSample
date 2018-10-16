using System;
using System.Collections.Generic;
using System.Text;

namespace EdaSample.Events
{
    public class EventProcessedEventArgs: EventArgs
    {
        public EventProcessedEventArgs(IEvents events)
        {
            this.Events = events;
        }

        public IEvents Events { get; }
    }
}
