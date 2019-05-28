using Cine.API.Models;
using System.Threading.Tasks;

namespace Cine.API.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        Task<bool> CreateReserva(Reserva reserva);
        Task<bool> CancelReserva(Reserva reserva);
    }
}
