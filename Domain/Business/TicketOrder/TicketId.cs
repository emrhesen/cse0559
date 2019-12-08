using EventFlow.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Business.TicketOrder
{
    public class TicketId : Identity<TicketId>
    {
        public TicketId(string value) : base(value)
        {
        }
    }
}
