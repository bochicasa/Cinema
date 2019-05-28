using Cine.API.Models;
using Cine.API.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.API.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        CineContext dbContext;
        readonly ILogger<ReservaRepository> _log;
        IConfiguration _configuration;

        public ReservaRepository(ILogger<ReservaRepository> log, IConfiguration configuration)
        {
            _configuration = configuration;
            _log = log;
            this.dbContext = new CineContext(_configuration);
        }
        public async Task<bool> CreateReserva(Reserva model)
        {
            var result = false;


            using (this.dbContext)
            {
                using (var transaction = this.dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var sillaLocalidadMapa = from s in dbContext.SillaLocalidadMapa
                                                 join m in dbContext.Mapa on s.Mapa equals m.Id
                                                 where m.Funcion == model.Funcion && s.Estado == 1
                                                 select s;
                        if (sillaLocalidadMapa.Count() >= model.NumSil)
                        {
                            int count = 1;
                            foreach (SillaLocalidadMapa sl in sillaLocalidadMapa)
                            {
                                if (count <= model.NumSil)
                                {
                                    Reserva reserva = new Reserva();
                                    reserva.Estado = "A";
                                    reserva.FechaRes = DateTime.Now;
                                    reserva.Funcion = model.Funcion;
                                    reserva.SecCliente = model.SecCliente;
                                    reserva.TipoRes = "I";
                                    reserva.SillaLocalidad = sl.Id;
                                    sl.Estado = 2;

                                    this.dbContext.SillaLocalidadMapa.Update(sl);
                                    this.dbContext.Reserva.Add(reserva);
                                    dbContext.SaveChanges();
                                    result = true;
                                    count++;
                                }
                            }
                        }
                        else
                        {
                            result = false;
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        _log.LogError(ex, ex.Message);
                        result = false;
                    }
                }
            }


            return result;

        }

        public async Task<bool> CancelReserva(Reserva model)
        {
            var result = false;
            using (this.dbContext)
            {
                using (var transaction = this.dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        List<Reserva> reservas = dbContext.Reserva.Where(r => r.SecCliente == model.SecCliente && r.Funcion == model.Funcion).ToList();

                        foreach (Reserva reserva in reservas)
                        {
                            SillaLocalidadMapa sillaLocalidadMapa = this.dbContext.SillaLocalidadMapa.Where(sl => sl.Id == reserva.SillaLocalidad).FirstOrDefault();
                            sillaLocalidadMapa.Estado = 1;

                            this.dbContext.SillaLocalidadMapa.Update(sillaLocalidadMapa);
                            this.dbContext.Reserva.Remove(reserva);
                            dbContext.SaveChanges();
                            result = true;
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        _log.LogError(ex, ex.Message);
                        result = false;
                    }
                }
            }
            return result;

        }
    }
}
