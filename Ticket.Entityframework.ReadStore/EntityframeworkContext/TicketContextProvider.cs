using EventFlow.EntityFramework;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.Entityframework.ReadStore.EntityframeworkContext
{
    public class TicketContextProvider : IDbContextProvider<TicketContext>
    {
        private readonly DbContextOptions<TicketContext> _options;

        public TicketContextProvider(EnvironmentConfiguration configuration)
        {
            _options = new DbContextOptionsBuilder<TicketContext>()
                .UseSqlServer(configuration.DbConnection)
                .Options;
        }

        public TicketContext CreateContext()
        {
            var db = new TicketContext(_options);
            db.Database.EnsureCreated();
            return db;
        }
    }
}
