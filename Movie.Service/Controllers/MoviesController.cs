using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Application.QueryServices;
using Domain.Business.Movie;
using EventFlow;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Service.Controllers
{
    [Route("Movie")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IMovieQueryService _movieQueryService;

        public MoviesController(ICommandBus commandBus, IMovieQueryService movieQueryService)
        {
            _commandBus = commandBus;
            _movieQueryService = movieQueryService;
        }

        public async Task<IActionResult> GetMovie(string Id,CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return BadRequest(nameof(NullReferenceException));
            }

            var result = await _movieQueryService.GetMovieByIdAsync(MovieId.With(Guid.Parse(Id)), cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> CreateMovie()
        {
            return Ok();
        }
    }
}