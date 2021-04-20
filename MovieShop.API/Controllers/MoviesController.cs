using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> Get30HighestGrossing()
        {
            var movies = await _movieService.Get30HighestGrossing();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenreAsync(genreId);
            return Ok(movies);
        }
    }
}
