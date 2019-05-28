using Cine.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cine.API.Repositories.Interfaces
{
    public interface IFuncionesRepository
    {
        Task<IEnumerable<Funcion>> GetFunctionsByEvent(decimal movieId);
        Task<IEnumerable<SillaLocalidadMapa>> GetSillasByFuncion(decimal funcionId);
        Task<decimal> GetCostoByFuncion(decimal funcionId);
    }
}
