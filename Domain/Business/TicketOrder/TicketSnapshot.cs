using EventFlow.Snapshots;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Business.TicketOrder
{
    public class TicketSnapshot : ISnapshot
    {
        public TicketAggregateState TicketState { get; }

        public TicketSnapshot(TicketAggregateState ticketState)
        {
            TicketState = ticketState;
        }
    }
}
