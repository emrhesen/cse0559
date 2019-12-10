using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Business.TicketOrder.Commands;
using EventFlow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketOrder.Service.DTO;

namespace TicketOrder.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public TicketController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost("save/sellTicket")]
        public async Task<IActionResult> SellTicket([FromBody] TicketDTO ticket, CancellationToken cancellationToken)
        {
            await _commandBus.PublishAsync(new RegisterTicketCommand(ticket.MovieId, ticket.FullName, ticket.Price),
                cancellationToken);

            return Ok();
        }
    }
}