using System;
using System.Collections.Generic;

namespace Cine.View.Services.ModelDtos
{
    public partial class FuncionDto
    {
        public decimal Id { get; set; }
        public DateTime FechaFun { get; set; }
        public decimal Pelicula { get; set; }
        public string Reservas { get; set; }

        public virtual ICollection<BoletaDto> Boleta { get; set; }
        public virtual ICollection<ReservaDto> Reserva { get; set; }
        public virtual ICollection<VentaDto> Venta { get; set; }
    }
}
