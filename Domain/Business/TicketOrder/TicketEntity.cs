using EventFlow.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Business.TicketOrder
{
    public class TicketEntity : Entity<TicketId>
    {
        public TicketEntity(TicketId id) : base(id)
        {
        }

        public string MovieId { get; set; }
        public string FullName { get; set; }
        public int Price { get; set; }
        public int Version { get; set; }
    }
}
