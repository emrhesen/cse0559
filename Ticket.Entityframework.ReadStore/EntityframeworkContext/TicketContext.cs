using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Entityframework.ReadStore.ReadModels;

namespace Ticket.Entityframework.ReadStore.EntityframeworkContext
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<TicketReadModel> Tickets { get; set; }
    }
}
