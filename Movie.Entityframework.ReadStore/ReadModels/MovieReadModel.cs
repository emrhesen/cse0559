using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Business.Movie;
using Domain.Business.Movie.Events;
using EventFlow.Aggregates;
using EventFlow.ReadStores;

namespace Movie.Entityframework.ReadStore.ReadModels
{
    public class MovieReadModel : IReadModel,
        IAmReadModelFor<MovieAggregate,MovieId,MovieRegisterCompleted>
    {
        [Key]
        [Column("Id")]
        public virtual string AggregateId { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public int Budget { get; set; }
        
        public void Apply(IReadModelContext context, IDomainEvent<MovieAggregate, MovieId, MovieRegisterCompleted> domainEvent)
        {
            var movie = domainEvent.AggregateEvent.Entity;

            AggregateId = domainEvent.AggregateIdentity.ToString();
            Name = movie.Name;
            Director = movie.Director;
            Budget = movie.Budget;
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