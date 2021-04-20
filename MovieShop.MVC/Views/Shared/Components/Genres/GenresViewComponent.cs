using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Views.Shared.Components.Genres
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreService _genreService;



        public GenresViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _genreService.GetAllGenres();
            // sends data to Default.cshtml
            // this method is called in layout using @await Component.InvokeAsync("Genres")
            return View(genres);
        }
    }
}
