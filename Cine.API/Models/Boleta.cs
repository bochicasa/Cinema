using System;
using System.Collections.Generic;

namespace Cine.API.Models
{
    public partial class Boleta
    {
        public decimal Id { get; set; }
        public decimal Mapa { get; set; }
        public decimal Funcion { get; set; }
        public decimal Sala { get; set; }
        public decimal Localidad { get; set; }
        public decimal NumSil { get; set; }
        public decimal CodVen { get; set; }
        public decimal SecCliente { get; set; }
        public decimal ValorBolVen { get; set; }

        public virtual Venta CodVenNavigation { get; set; }
        public virtual Funcion FuncionNavigation { get; set; }
        public virtual Localidad LocalidadNavigation { get; set; }
        public virtual Mapa MapaNavigation { get; set; }
        public virtual Silla NumSilNavigation { get; set; }
        public virtual Sala SalaNavigation { get; set; }
        public virtual Cliente SecClienteNavigation { get; set; }
    }
}
