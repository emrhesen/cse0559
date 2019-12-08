using Domain.Business.TicketOrder.Events;
using EventFlow.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Business.TicketOrder
{
    public class TicketAggregateState : AggregateState<TicketAggregate, TicketId, TicketAggregateState>,
        IApply<TicketRegisteredEvent>
    {
        public TicketEntity Entity { get; set; }

        public void Apply(TicketRegisteredEvent aggregateEvent)
        {
            Entity = aggregateEvent.Ticket;
        }

        public void LoadSnapshot(TicketSnapshot snapshot)
        {
            Entity = snapshot.TicketState.Entity;
        }
    }
}
