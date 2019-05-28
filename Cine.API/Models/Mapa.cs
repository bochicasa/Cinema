using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class Mapa
    {
        public Mapa()
        {
            Boleta = new HashSet<Boleta>();
            LocalidadMapa = new HashSet<LocalidadMapa>();
            SillaLocalidadMapa = new HashSet<SillaLocalidadMapa>();
        }

        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string TipoMap { get; set; }
        public decimal Sala { get; set; }
        public decimal Funcion { get; set; }
        public string Publicado { get; set; }

        public virtual Funcion FuncionNavigation { get; set; }
        public virtual Sala SalaNavigation { get; set; }
        public virtual ICollection<Boleta> Boleta { get; set; }
        public virtual ICollection<LocalidadMapa> LocalidadMapa { get; set; }
        public virtual ICollection<SillaLocalidadMapa> SillaLocalidadMapa { get; set; }
    }
}
