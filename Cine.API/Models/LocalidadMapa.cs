using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class LocalidadMapa
    {
        public decimal Id { get; set; }
        public decimal Localidad { get; set; }
        public decimal Mapa { get; set; }
        public decimal Costo { get; set; }

        public virtual Localidad LocalidadNavigation { get; set; }
        public virtual Mapa MapaNavigation { get; set; }
    }
}
