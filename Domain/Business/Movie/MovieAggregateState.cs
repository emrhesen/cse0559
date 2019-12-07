using Domain.Business.Movie.Events;
using EventFlow.Aggregates;

namespace Domain.Business.Movie
{
    public class MovieAggregateState : AggregateState<MovieAggregate,MovieId,MovieAggregateState>,
        IApply<MovieRegisteredEvent>
    {

        public MovieEntity Entity { get; set; }

        public void Apply(MovieRegisteredEvent aggregateEvent)
        {
            Entity = aggregateEvent.Movie;
        }

        public void LoadSnapshot(MovieSnapshot snapshot)
        {
            Entity = snapshot.MovieState.Entity;
        }
    }
}