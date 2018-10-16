using System;
using System.Collections.Generic;
using System.Text;

namespace EdaSample.Events
{
    public interface IEvents
    {
        Guid Id { get; }
        DateTime Timestamp { get; }
    }
}
