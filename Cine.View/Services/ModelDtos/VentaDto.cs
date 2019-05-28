using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.View.Services.ModelDtos
{
    public partial class VentaDto
    {
        public decimal Id { get; set; }
        public decimal SecCliente { get; set; }
        public DateTime FechaVen { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Funcion { get; set; }
        public decimal RespVen { get; set; }

        public virtual FuncionDto FuncionNavigation { get; set; }
        public virtual ClienteDto SecClienteNavigation { get; set; }
        public virtual ICollection<BoletaDto> Boleta { get; set; }
    }
}
