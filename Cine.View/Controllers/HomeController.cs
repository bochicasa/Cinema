using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cine.View.Models;
using Cine.View.Services;
using Polly.CircuitBreaker;

namespace Cine.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        
        //private readonly IIdentityParser<ApplicationUser> _appUserParser;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<IActionResult> Index()
        {
            try
            {
                var movies = await _movieService.GetPeliculas();
                return View(movies);
            }
            catch (BrokenCircuitException)
            {
                // Catch error when Basket.api is in circuit-opened mode                 
                HandleBrokenCircuitException();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void HandleBrokenCircuitException()
        {
            ViewBag.MovieDBProblemsMsg = "Servicio no disponible. (Circuit-Breaker )";
        }
    }
}
