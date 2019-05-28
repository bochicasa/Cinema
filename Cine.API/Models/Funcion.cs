using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class Funcion
    {
        public Funcion()
        {
            Boleta = new HashSet<Boleta>();
            Mapa = new HashSet<Mapa>();
            Reserva = new HashSet<Reserva>();
            Venta = new HashSet<Venta>();
        }

        public decimal Id { get; set; }
        public DateTime FechaFun { get; set; }
        public decimal Pelicula { get; set; }
        public string Reservas { get; set; }

        public virtual Pelicula PeliculaNavigation { get; set; }
        public virtual ICollection<Boleta> Boleta { get; set; }
        public virtual ICollection<Mapa> Mapa { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
