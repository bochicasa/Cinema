using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class Sala
    {
        public Sala()
        {
            Boleta = new HashSet<Boleta>();
            Localidad = new HashSet<Localidad>();
            Mapa = new HashSet<Mapa>();
        }

        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string Observaciones { get; set; }
        public string Direccion { get; set; }
        public string RutaImg { get; set; }

        public virtual ICollection<Boleta> Boleta { get; set; }
        public virtual ICollection<Localidad> Localidad { get; set; }
        public virtual ICollection<Mapa> Mapa { get; set; }
    }
}
