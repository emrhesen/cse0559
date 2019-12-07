using EventFlow.Aggregates;

namespace Domain.Business.Movie.Events
{
    public class MovieRegisteredEvent : AggregateEvent<MovieAggregate,MovieId>
    {
        public MovieEntity Movie { get; set; }

        public MovieRegisteredEvent(MovieEntity movie)
        {
            Movie = movie;
        }
    }
}