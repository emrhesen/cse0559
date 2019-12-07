using System.Threading;
using System.Threading.Tasks;
using Domain.Application.QueryServices;
using Domain.Business.Movie;
using EventFlow.Queries;
using Movie.Entityframework.ReadStore.ReadModels;

namespace Movie.Entityframework.ReadStore.Services
{
    public class MovieQueryService : IMovieQueryService
    {
        private readonly IQueryProcessor _queryProcessor;

        public MovieQueryService(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }


        public async Task<MovieEntity> GetMovieByIdAsync(MovieId id, CancellationToken ctx)
        {
            var result = await _queryProcessor.ProcessAsync(new ReadModelByIdQuery<MovieReadModel>(id), ctx);

            return result?.ToMovie();
        }
    }
}