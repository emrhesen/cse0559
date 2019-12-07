using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Business.Movie.Commands
{
    public class UpdateMovieCommand : Command<MovieAggregate, MovieId, IExecutionResult>
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public int Budget { get; set; }

        public UpdateMovieCommand(MovieId aggregateId,string name , string director , int budget) : base(aggregateId)
        {
            Name = name;
            Director = director;
            Budget = budget;
        }
    }

    internal class UpdateMovieCommandHandler : CommandHandler<MovieAggregate, MovieId, IExecutionResult, UpdateMovieCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(MovieAggregate aggregate, UpdateMovieCommand command, CancellationToken cancellationToken)
        {
            var result = aggregate.UpdateMovie(command.Name, command.Director, command.Budget);

            return Task.FromResult(result);
        }
    }
}
