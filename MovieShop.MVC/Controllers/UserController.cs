using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserPurchasedMovies()
        {
            // call User service by id for user to get all movies he/she purchased
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchaseMovie()
        {
            return View();
        }
    }
}
