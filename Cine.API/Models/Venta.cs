using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Boleta = new HashSet<Boleta>();
        }

        public decimal Id { get; set; }
        public decimal SecCliente { get; set; }
        public DateTime FechaVen { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Funcion { get; set; }
        public decimal RespVen { get; set; }

        public virtual Funcion FuncionNavigation { get; set; }
        public virtual Cliente SecClienteNavigation { get; set; }
        public virtual ICollection<Boleta> Boleta { get; set; }
    }
}
