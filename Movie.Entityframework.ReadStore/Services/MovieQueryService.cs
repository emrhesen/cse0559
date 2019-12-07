using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Application.QueryServices;
using Domain.Business.Movie;
using EventFlow.Queries;
using Infrastructure.ReadStores;
using Movie.Entityframework.ReadStore.ReadModels;

namespace Movie.Entityframework.ReadStore.Services
{
    public class MovieQueryService : IMovieQueryService
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ISearchableReadModelStore<MovieReadModel> _readModelStore;

        public MovieQueryService(IQueryProcessor queryProcessor, ISearchableReadModelStore<MovieReadModel> readModelStore)
        {
            _queryProcessor = queryProcessor;
            _readModelStore = readModelStore;
        }


        public async Task<MovieEntity> GetMovieByIdAsync(MovieId id, CancellationToken ctx)
        {
            var result = await _queryProcessor.ProcessAsync(new ReadModelByIdQuery<MovieReadModel>(id), ctx);

            return result?.ToMovie();
        }

        public async Task<IEnumerable<MovieEntity>> ListMovie(CancellationToken ctx)
        {
            var readModel = await _readModelStore.FindAsync(x => true, ctx);

            return readModel.Select(x => x.ToMovie()).ToList();
        }
    }
}