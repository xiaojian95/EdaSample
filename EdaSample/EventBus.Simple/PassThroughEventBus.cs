using EdaSample.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdaSample.EventBus.Simple
{
    public sealed class PassThroughEventBus : IEventBus
    {
        private readonly EventQueue eventQueue = new EventQueue();
        private readonly IEnumerable<IEventHandler> eventHandlers;
        public PassThroughEventBus(IEnumerable<IEventHandler> eventHandlers)
        {
            this.eventHandlers = eventHandlers;
        }

        private void EventQueu_EventPushed(object sender, EventProcessedEventArgs e)
            => (from eh in this.eventHandlers where eh.CanHandle(e.Events)
                select eh).ToList().ForEach(async eh => await eh.HandleAsync(e.Events));

        public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvents
            => Task.Factory.StartNew(() => eventQueue.Push(@event));

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : IEvents
            where TEventHandler : IEventHandler<TEvent>
            => eventQueue.EventPushed += EventQueu_EventPushed;
    }
}
