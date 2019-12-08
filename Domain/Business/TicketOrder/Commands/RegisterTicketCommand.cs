using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Business.TicketOrder.Commands
{
    public class RegisterTicketCommand : Command<TicketAggregate, TicketId, IExecutionResult>
    {
        public string MovieId { get; set; }
        public string FullName { get; set; }
        public int Price { get; set; }

        public RegisterTicketCommand(string movieId,string fullName,int price) : base(TicketId.New)
        {
            MovieId = movieId;
            FullName = fullName;
            Price = price;
        }
    }

    internal class RegisterTicketCommandHandler : CommandHandler<TicketAggregate, TicketId, IExecutionResult, RegisterTicketCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(TicketAggregate aggregate, RegisterTicketCommand command, CancellationToken cancellationToken)
        {
            var result = aggregate.RegisterTicket(command.MovieId, command.FullName, command.Price);

            return Task.FromResult(result);
        }
    }
}
