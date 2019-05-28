using Cine.View.Services;
using Cine.View.Services.ModelDtos;
using Cine.View.ViewModel.Movie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.View.Controllers
{
    public class ConfirmacionController : Controller
    {
        private readonly IReservaService _reservaService;
        private readonly IMovieService _movieService;

        public ConfirmacionController(IReservaService reservaService, IMovieService movieService)
        {
            _reservaService = reservaService;
            _movieService = movieService;
        }
        // GET: Confirmacion
        public async Task<IActionResult> Index(ReservaDetalle model, string answer)
        {
            int funcionId = Convert.ToInt32(model.selectedFuncion.Id);
            List<Movie> peliculas = await _movieService.GetPeliculas();
            Movie movie = peliculas.Where(i => i.id == model.movie.id).FirstOrDefault();
            ConfirmacionDetalle confirmacionDetalle = new ConfirmacionDetalle();
            switch (answer)
            {
                case "Reservar":

                    decimal precioBase = await _reservaService.GetCostoByFuncion(funcionId);
                    ReservaDto reserva = new ReservaDto();
                    reserva.SecCliente = 1;
                    reserva.Funcion = funcionId;
                    reserva.NumSil = Convert.ToInt32(model.numeroSillasSelected);
                    var result = await _reservaService.PostReserva(reserva);
                    if (result.IsSuccessStatusCode)
                    {

                        decimal precio = (precioBase * (Convert.ToDecimal(model.movie.vote_average) / 10)) * Convert.ToDecimal(model.numeroSillasSelected);
                        confirmacionDetalle.imagen = @"https://image.tmdb.org/t/p/w185_and_h278_bestv2/" + movie.poster_path;
                        confirmacionDetalle.valorVenta = precio;
                        confirmacionDetalle.movie = movie;
                        confirmacionDetalle.mensaje = "Reserva exitosa";
                    }
                    else
                    {
                        confirmacionDetalle.mensaje = "Reserva fallida";
                    }

                    break;
                case "Cancelar":
                    ReservaDto reservaCancel = new ReservaDto();
                    reservaCancel.SecCliente = 1;
                    reservaCancel.Funcion = funcionId;

                    var cancel = await _reservaService.PostCancelReserva(reservaCancel);

                    if (cancel.IsSuccessStatusCode)
                    {
                        confirmacionDetalle.imagen = @"https://image.tmdb.org/t/p/w185_and_h278_bestv2/" + movie.poster_path;
                        confirmacionDetalle.movie = movie;
                        confirmacionDetalle.mensaje = "Cancelacion reserva exitosa";
                    }
                    else
                    {
                        confirmacionDetalle.mensaje = "Problemas en la cancelacion";
                    }
                    break;
                   
            }
            return View(confirmacionDetalle);
        }

        // GET: Confirmacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Confirmacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Confirmacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Confirmacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Confirmacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Confirmacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Confirmacion/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}