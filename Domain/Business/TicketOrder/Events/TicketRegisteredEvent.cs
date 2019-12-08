using EventFlow.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Business.TicketOrder.Events
{
    public class TicketRegisteredEvent : AggregateEvent<TicketAggregate, TicketId>
    {
        public TicketEntity Ticket { get; set; }

        public TicketRegisteredEvent(TicketEntity ticket)
        {
            Ticket = ticket;
        }
    }
}
