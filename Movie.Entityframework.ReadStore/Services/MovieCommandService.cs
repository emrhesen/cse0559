using System.Threading;
using System.Threading.Tasks;
using Domain.Application.CommandServices;
using Domain.Business.Movie;
using Domain.Business.Movie.Commands;
using EventFlow;

namespace Movie.Entityframework.ReadStore.Services
{
    public class MovieCommandService : IMovieCommandService
    {
        private readonly ICommandBus _commandBus;

        public MovieCommandService(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        
        public async Task CreateNewMovieAsync(MovieEntity entity, CancellationToken ctx)
        {
            await _commandBus.PublishAsync(new RegisterMovieCommand(entity.Name,entity.Director,entity.Budget), ctx);
        }

        public async Task UpdateMovieAsync(MovieId movieId, string name, string director, int budget, CancellationToken ctx)
        {
            await _commandBus.PublishAsync(new UpdateMovieCommand(movieId,name, director, budget), ctx);
        }
    }
}