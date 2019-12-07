using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Business.Movie;
using Domain.Business.Movie.Events;
using EventFlow.Aggregates;
using EventFlow.ReadStores;

namespace Movie.Entityframework.ReadStore.ReadModels
{
    public class MovieReadModel : IReadModel,
        IAmReadModelFor<MovieAggregate,MovieId,MovieRegisteredEvent>,
        IAmReadModelFor<MovieAggregate,MovieId,MovieUpdatedEvent>
    {
        [Key]
        [Column("Id")]
        public virtual string AggregateId { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public int Budget { get; set; }
        
        public void Apply(IReadModelContext context, IDomainEvent<MovieAggregate, MovieId, MovieRegisteredEvent> domainEvent)
        {
            var movie = domainEvent.AggregateEvent.Movie;

            AggregateId = domainEvent.AggregateIdentity.ToString();
            Name = movie.Name;
            Director = movie.Director;
            Budget = movie.Budget;
        }

        public void Apply(IReadModelContext context, IDomainEvent<MovieAggregate, MovieId, MovieUpdatedEvent> domainEvent)
        {
            var updatedMovie = domainEvent.AggregateEvent;

            Name = updatedMovie.Name;
            Director = updatedMovie.Director;
            Budget = updatedMovie.Budget;
        }

        public MovieEntity ToMovie()
        {
            return new MovieEntity(MovieId.With(AggregateId))
            {
                Name = Name,
                Director = Director,
                Budget = Budget
            };
        }
    }
}