using Cine.API.Models;
using Cine.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Cine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {

        private IFuncionesRepository _repository;
        private IReservaRepository _reservaRepository;
        readonly ILogger<ReservaController> _log;

        public ReservaController(IFuncionesRepository repository, ILogger<ReservaController> log, IReservaRepository reservaRepository)
        {
            _repository = repository;
            _reservaRepository = reservaRepository;
            _log = log;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Funcion), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFuncionesByMovieAsync(decimal id)
        {
            IEnumerable<Funcion> funciones = await _repository.GetFunctionsByEvent(id);
            return Ok(funciones);
        }

        [HttpGet("silla/{funcionId}")]
        [ProducesResponseType(typeof(SillaLocalidadMapa), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SillaLocalidadMapa>>> GetSillasByFUncionAsync(decimal funcionId)
        {
            IEnumerable<SillaLocalidadMapa> funciones = await _repository.GetSillasByFuncion(funcionId);
            return Ok(funciones);
        }

        [HttpGet("costo/{funcionId}")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<decimal>> GetCostoByFUncionAsync(decimal funcionId)
        {
            decimal funciones = await _repository.GetCostoByFuncion(funcionId);
            return Ok(funciones);
        }

        [HttpPost]
        [Route("PostReserva")]
        public async Task<IActionResult> PostReserva([FromBody] Reserva model)
        {
            try
            {
                return Ok(await _reservaRepository.CreateReserva(model));
            }
            catch (System.Exception ex)
            {

                _log.LogError(ex, ex.Message);
                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("PostCancelReserva")]
        public async Task<IActionResult> PostCancelReserva([FromBody] Reserva model)
        {
            try
            {
                return Ok(await _reservaRepository.CancelReserva(model));
            }
            catch (System.Exception ex)
            {

                _log.LogError(ex, ex.Message);
                return BadRequest(ex);
            }

        }
    }
}
