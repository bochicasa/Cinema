using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class Reserva
    {
        public decimal Id { get; set; }
        public decimal Funcion { get; set; }
        public decimal NumSil { get; set; }
        public DateTime FechaRes { get; set; }
        public string TipoRes { get; set; }
        public decimal SecCliente { get; set; }
        public string Estado { get; set; }
        public decimal SillaLocalidad { get; set; }

        public virtual Funcion FuncionNavigation { get; set; }
        public virtual Cliente SecClienteNavigation { get; set; }
        public virtual SillaLocalidadMapa SillaLocalidadNavigation { get; set; }
    }
}
