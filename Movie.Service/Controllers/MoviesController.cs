using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Application.QueryServices;
using Domain.Business.Movie;
using Domain.Business.Movie.Commands;
using EventFlow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Service.DTO;

namespace Movie.Service.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<IActionResult> GetMovie(string Id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return BadRequest(nameof(NullReferenceException));
            }

            var result = await _movieQueryService.GetMovieByIdAsync(MovieId.With(Guid.Parse(Id)), cancellationToken);
            return new JsonResult(result);
        }

        [HttpPost("save/createMovie")]
        public async Task<IActionResult> CreateMovie(MovieDTO movie, CancellationToken cancellationToken)
        {
            await _commandBus.PublishAsync(new RegisterMovieCommand(movie.Name, movie.Director, movie.Budget),
                cancellationToken);
            
            return Ok();
        }
    }
}