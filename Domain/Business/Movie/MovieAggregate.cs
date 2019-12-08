using System.Threading;
using System.Threading.Tasks;
using Domain.Business.Movie.Events;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Snapshots;
using EventFlow.Snapshots.Strategies;

namespace Domain.Business.Movie
{
    public class MovieAggregate : SnapshotAggregateRoot<MovieAggregate,MovieId,MovieSnapshot>
    {
        private readonly MovieAggregateState _movieAggregateState = new MovieAggregateState();
        
        public MovieAggregate(MovieId Id) : base(Id, SnapshotEveryFewVersionsStrategy.With(2))
        {
            Register(_movieAggregateState);
        }

        #region EmitEventSection

        public IExecutionResult RegisterMovie(string name,string director , int budget)
        {
            Emit(new MovieRegisteredEvent(new MovieEntity(this.Id)
            {
                Name = name,
                Director = director,
                Budget = budget
            }));
            
            return ExecutionResult.Success();
        }

        public IExecutionResult UpdateMovie(string name, string director, int budget)
        {
            var movie = _movieAggregateState.Entity;

            movie.Name = name;
            movie.Director = director;
            movie.Budget = budget;

            Emit(new MovieUpdatedEvent(name,director,budget));

            return ExecutionResult.Success();
        }

        #endregion

        protected override Task<MovieSnapshot> CreateSnapshotAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new MovieSnapshot(_movieAggregateState));
        }

        protected override Task LoadSnapshotAsync(MovieSnapshot snapshot, ISnapshotMetadata metadata, CancellationToken cancellationToken)
        {
            _movieAggregateState.LoadSnapshot(snapshot);
            return Task.CompletedTask;
        }
    }
}