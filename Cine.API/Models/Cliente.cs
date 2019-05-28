using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Boleta = new HashSet<Boleta>();
            Reserva = new HashSet<Reserva>();
            Venta = new HashSet<Venta>();
        }

        public decimal SecCli { get; set; }
        public decimal Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Boleta> Boleta { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
