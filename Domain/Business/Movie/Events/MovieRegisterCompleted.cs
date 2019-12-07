using EventFlow.Aggregates;

namespace Domain.Business.Movie.Events
{
    public class MovieRegisterCompleted : AggregateEvent<MovieAggregate,MovieId>
    {
        public MovieEntity Entity { get; }

        public MovieRegisterCompleted(MovieEntity entity)
        {
            Entity = entity;
        }
    }
}