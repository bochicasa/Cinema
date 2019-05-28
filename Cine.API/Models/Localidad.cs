using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class Localidad
    {
        public Localidad()
        {
            Boleta = new HashSet<Boleta>();
            LocalidadMapa = new HashSet<LocalidadMapa>();
            Silla = new HashSet<Silla>();
            SillaLocalidadMapa = new HashSet<SillaLocalidadMapa>();
        }

        public decimal Id { get; set; }
        public decimal Sala { get; set; }
        public string Nombre { get; set; }
        public string Observaciones { get; set; }

        public virtual Sala SalaNavigation { get; set; }
        public virtual ICollection<Boleta> Boleta { get; set; }
        public virtual ICollection<LocalidadMapa> LocalidadMapa { get; set; }
        public virtual ICollection<Silla> Silla { get; set; }
        public virtual ICollection<SillaLocalidadMapa> SillaLocalidadMapa { get; set; }
    }
}
