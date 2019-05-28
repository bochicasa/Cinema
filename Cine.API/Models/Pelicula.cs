using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Funcion = new HashSet<Funcion>();
        }

        public decimal Id { get; set; }
        public string OriginalTitle { get; set; }

        public virtual ICollection<Funcion> Funcion { get; set; }
    }
}
