using Cine.API.Models;
using Cine.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.API.Repositories
{
    public class FuncionesRepository : IFuncionesRepository
    {
        CineContext dbContext;
        readonly ILogger<FuncionesRepository> _log;
        IConfiguration _configuration;

        public FuncionesRepository(ILogger<FuncionesRepository> log, IConfiguration configuration)
        {
            _configuration = configuration;
            _log = log;
            this.dbContext = new CineContext(_configuration);
        }

        public async Task<IEnumerable<Funcion>> GetFunctionsByEvent(decimal movieId)
        {
            IEnumerable<Funcion> result;
            try
            {
                result = await dbContext.Funcion.Where(m => m.Pelicula == movieId).ToListAsync();
            }
            catch (Exception ex)
            {

                _log.LogError(ex, ex.Message);
                throw;
            }
            return result;

        }

        public async Task<IEnumerable<SillaLocalidadMapa>> GetSillasByFuncion(decimal funcionId)
        {
            IEnumerable<SillaLocalidadMapa> result;
            try
            {
                result = from s in dbContext.SillaLocalidadMapa
                         join m in dbContext.Mapa on s.Mapa equals m.Id
                         where m.Funcion == funcionId && s.Estado == 1
                         select s;

            }
            catch (Exception ex)
            {

                _log.LogError(ex, ex.Message);
                throw;
            }
            return result;

        }

        public async Task<decimal> GetCostoByFuncion(decimal funcionId)
        {
            decimal result;
            try
            {
                var resultq = from s in dbContext.LocalidadMapa
                         join m in dbContext.Mapa on s.Mapa equals m.Id
                         where m.Funcion == funcionId 
                         select s;
                result = resultq.FirstOrDefault().Costo;

            }
            catch (Exception ex)
            {

                _log.LogError(ex, ex.Message);
                throw;
            }
            return result;

        }

    }
}
