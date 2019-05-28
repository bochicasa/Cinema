using Cine.View.Services.ModelDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cine.View.Services
{
    public interface IFuncionService
    {
        Task<List<FuncionDto>> GetFunciones(decimal movieId);
    }
}
