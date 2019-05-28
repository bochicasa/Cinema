using Cine.View.Services.ModelDtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cine.View.Services
{
    public interface IReservaService
    {
        Task<List<FuncionDto>> GetFuncionesByMovie(decimal id);
        Task<List<SillaLocalidadMapaDto>> GetSilaByFuncion(decimal funcionId);
        Task<decimal> GetCostoByFuncion(decimal funcionId);
        Task<HttpResponseMessage> PostReserva(ReservaDto reserva);
        Task<HttpResponseMessage> PostCancelReserva(ReservaDto reserva);
    }
}
