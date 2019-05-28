using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class SillaLocalidadMapa
    {
        public SillaLocalidadMapa()
        {
            Reserva = new HashSet<Reserva>();
        }

        public decimal Id { get; set; }
        public decimal Localidad { get; set; }
        public decimal NumSil { get; set; }
        public decimal Mapa { get; set; }
        public decimal Estado { get; set; }

        public virtual Localidad LocalidadNavigation { get; set; }
        public virtual Mapa MapaNavigation { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
