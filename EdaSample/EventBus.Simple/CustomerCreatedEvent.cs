using EdaSample.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdaSample.EventBus.Simple
{
    public class CustomerCreatedEvent:IEvents
    {
        public CustomerCreatedEvent(string customerName, string email)
        {
            this.Id = Guid.NewGuid();
            this.Timestamp = DateTime.UtcNow;
            this.CustomerName = customerName;
            this.Email = email;
        }

        public Guid Id { get; }

        public DateTime Timestamp { get; }

        public string CustomerName { get; }

        public string Email { get; }
    }
}
