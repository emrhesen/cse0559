using EventFlow.Snapshots;

namespace Domain.Business.Movie
{
    public class MovieSnapshot : ISnapshot
    {
        public MovieAggregateState MovieState { get; }

        public MovieSnapshot(MovieAggregateState movieState)
        {
            MovieState = movieState;
        }
    }
}