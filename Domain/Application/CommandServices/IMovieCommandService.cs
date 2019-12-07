using System.Threading;
using System.Threading.Tasks;
using Domain.Business.Movie;

namespace Domain.Application.CommandServices
{
    public interface IMovieCommandService
    {
        Task CreateNewMovieAsync(MovieEntity entity, CancellationToken ctx);
        Task UpdateMovieAsync(MovieId movieId, string name, string director, int budget, CancellationToken ctx);
    }
}