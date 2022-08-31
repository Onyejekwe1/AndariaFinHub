using AndariaFinHub.Domain.Common;
using AndariaFinHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndariaFinHub.Domain.Event
{
    public class CustomerCreatedEvent : DomainEvent
    {
        public CustomerCreatedEvent(Customer customer)
        {
            Customer = customer;
        }

        public Customer Customer { get; set; }
    }
}
