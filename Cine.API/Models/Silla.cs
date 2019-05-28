using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class Silla
    {
        public Silla()
        {
            Boleta = new HashSet<Boleta>();
        }

        public decimal NumSil { get; set; }
        public decimal Localidad { get; set; }
        public string NomFil { get; set; }
        public decimal FilSil { get; set; }
        public decimal ColSil { get; set; }
        public string ObsSil { get; set; }

        public virtual Localidad LocalidadNavigation { get; set; }
        public virtual ICollection<Boleta> Boleta { get; set; }
    }
}
