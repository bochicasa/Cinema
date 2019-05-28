using Cine.View.Services;
using Cine.View.Services.ModelDtos;
using Cine.View.ViewModel.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.View.Controllers
{
    public class ReservaController : Controller
    {
        private readonly IReservaService _reservaService;
        private readonly IMovieService _movieService;
        public ReservaController(IReservaService reservaService, IMovieService movieService)
        {
            _reservaService = reservaService;
            _movieService = movieService;
        }
        // GET: Reserva
        public ActionResult Index(decimal id)
        {
            try
            {
                ReservaDetalle reservaDetalle = new ReservaDetalle();
                List<Movie> peliculas = _movieService.GetPeliculas().Result;
                Movie movie = peliculas.Where(i => i.id == id).FirstOrDefault();
                List<FuncionDto> funciones = _reservaService.GetFuncionesByMovie(movie.id).Result;

                var numSillas = new List<SelectListItem>();
                numSillas.Add(new SelectListItem() { Text = "Select numero sillas", Value = string.Empty });
                numSillas.Add(new SelectListItem() { Text = "1", Value = "1" });
                numSillas.Add(new SelectListItem() { Text = "2", Value = "3" });
                numSillas.Add(new SelectListItem() { Text = "3", Value = "3" });
                numSillas.Add(new SelectListItem() { Text = "4", Value = "4" });
                numSillas.Add(new SelectListItem() { Text = "5", Value = "5" });
                numSillas.Add(new SelectListItem() { Text = "6", Value = "6" });
                numSillas.Add(new SelectListItem() { Text = "7", Value = "7" });
                numSillas.Add(new SelectListItem() { Text = "8", Value = "8" });
                numSillas.Add(new SelectListItem() { Text = "9", Value = "9" });
                numSillas.Add(new SelectListItem() { Text = "10", Value = "10" });

                ViewBag.NumSillas = numSillas;
                reservaDetalle.movie = movie;
                reservaDetalle.funciones = funciones;
                ViewBag.Sillas = "Seleccione una funcion";
                ViewBag.Image = @"https://image.tmdb.org/t/p/w185_and_h278_bestv2/" + movie.poster_path;
                return View(reservaDetalle);
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        [HttpPost]

        public async Task<JsonResult> RefreshPage(string id)
        {
            var resultado = new BaseRespuesta();
            decimal funcionId;
            if (!decimal.TryParse(id, out funcionId))
            {
                resultado.Mensaje = "Error consutando la informacion de las sillas";
                throw new ApplicationException("Error consutando la informacion de las sillas");

            }
            else
            {
                List<SillaLocalidadMapaDto> sillas = await _reservaService.GetSilaByFuncion(Convert.ToInt32(funcionId));
                resultado.OK = "true";
                resultado.Mensaje = "Sillas disponibles" + sillas.Count().ToString();
                resultado.Sillas = sillas.Count().ToString();

                return Json(resultado);

            }

        }

    }

    public class BaseRespuesta
    {
        public string OK { get; set; }
        public string Mensaje { get; set; }
        public string Sillas { get; set; }
    }
}

