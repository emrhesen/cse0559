using Domain.Application.CommandServices;
using Domain.Business.TicketOrder;
using Domain.Business.TicketOrder.Commands;
using EventFlow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ticket.Entityframework.ReadStore.Services
{
    public class TicketCommandService : ITicketCommandService
    {
        private readonly ICommandBus _commandBus;

        public TicketCommandService(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public async Task SellTicketAsync(TicketEntity entity, CancellationToken ctx)
        {
            await _commandBus.PublishAsync(new RegisterTicketCommand(entity.MovieId, entity.FullName, entity.Price), ctx);
        }
    }
}
