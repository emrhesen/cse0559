using Domain.Business.Movie.Events;
using Domain.Business.TicketOrder.Events;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Snapshots;
using EventFlow.Snapshots.Strategies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Business.TicketOrder
{
    public class TicketAggregate : SnapshotAggregateRoot<TicketAggregate, TicketId, TicketSnapshot>
    {
        private readonly TicketAggregateState _ticketAggregateState = new TicketAggregateState();

        public TicketAggregate(TicketId id) : base(id,SnapshotEveryFewVersionsStrategy.With(2))
        {
            Register(_ticketAggregateState);
        }

        #region EmitEventSection

        public IExecutionResult RegisterTicket(string movieId, string fullname, int price)
        {
            Emit(new TicketRegisteredEvent(new TicketEntity(this.Id)
            {
                MovieId = movieId,
                FullName = fullname,
                Price = price
            }));

            return ExecutionResult.Success();
        }

        #endregion

        protected override Task<TicketSnapshot> CreateSnapshotAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new TicketSnapshot(_ticketAggregateState));
        }

        protected override Task LoadSnapshotAsync(TicketSnapshot snapshot, ISnapshotMetadata metadata, CancellationToken cancellationToken)
        {
            _ticketAggregateState.LoadSnapshot(snapshot);
            return Task.CompletedTask;
        }
    }
}
