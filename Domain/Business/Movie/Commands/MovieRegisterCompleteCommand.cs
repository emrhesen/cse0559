using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using EventFlow.Core;

namespace Domain.Business.Movie.Commands
{
    public class MovieRegisterCompleteCommand : Command<MovieAggregate,MovieId>
    {
        public MovieEntity Entity { get; }
        
        public MovieRegisterCompleteCommand(MovieEntity entity) : base(entity.Id)
        {
            Entity = entity;
        }
    }

    internal class
        MovieRegisterCompleteCommandHandler : CommandHandler<MovieAggregate, MovieId, MovieRegisterCompleteCommand>
    {
        public override Task ExecuteAsync(MovieAggregate aggregate, MovieRegisterCompleteCommand command, CancellationToken cancellationToken)
        {
            aggregate.RegisterComplete(command.Entity);
            
            return Task.CompletedTask;
        }
    }
}