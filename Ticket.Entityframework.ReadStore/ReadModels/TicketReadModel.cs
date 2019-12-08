using Domain.Business.TicketOrder;
using Domain.Business.TicketOrder.Events;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ticket.Entityframework.ReadStore.ReadModels
{
    public class TicketReadModel : IReadModel,
        IAmReadModelFor<TicketAggregate, TicketId, TicketRegisteredEvent>
    {
        [Key]
        [Column("Id")]
        public virtual string AggregateId { get; set; }
        public string MovieId { get; set; }
        public string FullName { get; set; }
        public int Price { get; set; }
        public int Version { get; set; }

        public void Apply(IReadModelContext context, IDomainEvent<TicketAggregate, TicketId, TicketRegisteredEvent> domainEvent)
        {
            var ticket = domainEvent.AggregateEvent.Ticket;

            AggregateId = domainEvent.AggregateIdentity.ToString();
            FullName = ticket.FullName;
            Price = ticket.Price;
            MovieId = ticket.MovieId;
            Version = domainEvent.AggregateSequenceNumber;
        }

        public TicketEntity ToMovie()
        {
            return new TicketEntity(TicketId.With(AggregateId))
            {
                MovieId = MovieId,
                FullName = FullName,
                Price = Price
            };
        }
    }
}
