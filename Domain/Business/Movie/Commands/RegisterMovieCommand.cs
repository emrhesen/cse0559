using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using EventFlow.Core;

namespace Domain.Business.Movie.Commands
{
    public class RegisterMovieCommand : Command<MovieAggregate,MovieId,IExecutionResult>
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public int Budget { get; set; }

        public RegisterMovieCommand(string name, string director, int budget) : base(MovieId.New)
        {
            Name = name;
            Director = director;
            Budget = budget;
        }
    }

    internal class RegisteredMovieCommandHandler : CommandHandler<MovieAggregate,MovieId,IExecutionResult,RegisterMovieCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(MovieAggregate aggregate, RegisterMovieCommand command, CancellationToken cancellationToken)
        {
            var result = aggregate.RegisterMovie(command.Name, command.Director, command.Budget);

            return Task.FromResult(result);
        }
    }
}