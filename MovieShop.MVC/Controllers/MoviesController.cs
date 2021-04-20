using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Response;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.Get30HighestGrossing();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // should call Movie Service to get the details of the Movie that includes 
            // Movie details, Cast for that movie, Rating for that movie
            var movie = await _movieService.GetMovieAsync(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateRequestModel model)
        {
            _movieService.CreateMovie(model);
            return RedirectToAction("Index"); 
        }
        [HttpGet]
        public async Task<IActionResult> Genre(int Id)
        {
            var movies = await _movieService.GetMoviesByGenreAsync(Id);
            return View("Genre", movies);
        }

    }
}
