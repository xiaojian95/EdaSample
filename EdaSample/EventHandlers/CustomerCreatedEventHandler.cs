using EdaSample.EventBus.Simple;
using EdaSample.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdaSample.EventHandlers
{
    public class CustomerCreatedEventHandler : IEventHandler<CustomerCreatedEvent>
    {
        public bool CanHandle(IEvents events)
            => events.GetType().Equals(typeof(CustomerCreatedEvent));

        public Task<bool> HandleAsync(CustomerCreatedEvent events, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        public Task<bool> HandleAsync(IEvents events, CancellationToken cancellationToken = default) => CanHandle(events)? HandleAsync((CustomerCreatedEvent)events,cancellationToken):Task.FromResult(false);
    }
}
