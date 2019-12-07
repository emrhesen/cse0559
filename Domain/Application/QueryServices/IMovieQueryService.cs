using System.Threading;
using System.Threading.Tasks;
using Domain.Business.Movie;

namespace Domain.Application.QueryServices
{
    public interface IMovieQueryService
    {
        Task<MovieEntity> GetMovieByIdAsync(MovieId id,CancellationToken ctx);
    }
}