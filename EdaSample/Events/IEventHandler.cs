using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdaSample.Events
{
    public interface IEventHandler
    {
        Task<bool> HandleAsync(IEvents @event, CancellationToken cancellationToken = default);

        bool CanHandle(IEvents @event);
    }

    public interface IEventHandler<in T> : IEventHandler
        where T : IEvents
    {
        Task<bool> HandleAsync(T @event, CancellationToken cancellationToken = default);
    }
}
